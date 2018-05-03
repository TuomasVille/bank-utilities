using System;
using BankApp2.Repositories;
using BankApp2.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("BankApp v.2.1");
            DeleteCustomer();
            Console.WriteLine("Press <Enter> to exit!");
            Console.ReadLine();
        }

        static void CreateBank()
        {
            BankRepository br = new BankRepository();

            Bank b = new Bank("Burns Bank", "BUBKFIHH");
            br.CreateBank(b);

            Bank b2 = new Bank("Flanders Bank", "FABKFIHH");
            br.CreateBank(b2);
        }

        static void UpdateBank()
        {
            BankRepository br = new BankRepository();
            Bank uB = br.GetBankById(1);
            uB.Name = "Syzlak Bank";
            uB.Bic = "SYBKFIHH";
            br.UpdateBank(1, uB);
        }

        static void DeleteBank()
        {
            BankRepository br = new BankRepository();
            br.DeleteBank(2);
        }

        static void CreateCustomer()
        {
            CustomerRepository cR = new CustomerRepository();

            Customer c = new Customer("Milhouse", "Van Houten");
            cR.CreateCustomer(c);

            Customer c2 = new Customer("Montogomery", "Burns");
            cR.CreateCustomer(c2);
        }

        static void UpdateCustomer()
        {
            CustomerRepository cR = new CustomerRepository();
            Customer uC = cR.GetCustomerById(6);
            uC.FirstName = "Ned";
            uC.LastName = "Flanders";
            cR.UpdateCustomer(1, uC);
        }

        static void DeleteCustomer()
        {
            CustomerRepository cR = new CustomerRepository();
            cR.DeleteCustomer(3);
        }

        static void AddTransaction()
        {
            AccountRepository aR = new AccountRepository();
            Account account = aR.GetAccountByIban("FI1234567890112233");
            Transaction transaction = new Transaction
            {
                Iban = "FI1234567890112233",
                Amount = 20000,
                TimeStamp = DateTime.Today
            };
            aR.AddTransaction(transaction);
        }

        static void PrintAll()
        {
            BankRepository bR = new BankRepository();

            var bankCustomers = bR.GetTransactionsFromBanksCustomersAccounts();

            foreach (var bC in bankCustomers)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"\t{cAccount.ToString()}");
                        foreach (var trn in cAccount.Transaction)
                        {
                            Console.WriteLine($"\t{trn.ToString()}");
                        }
                    }
                }
            }
        }
    }
}