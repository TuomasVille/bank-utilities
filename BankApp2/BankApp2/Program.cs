using System;
using BankLibrary.Repository;
using BankLibrary.Model;
using System.Collections.Generic;



namespace BankApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BankApp v.2.1");

            BankRepository br = new BankRepository();
            Bank bank = new Bank
            {
                Name = "Ankkalinnan pankki",
                Bic = "BICANKKA",
                Account = new List<Account>
                {
                    new Account
                    {
                        Iban = "FI1234567890111213",
                        Name = "Aku Ankka",
                        Balance = 2000                      
                    }
                }           
            };
            br.Create(bank);

            TransactionRepository tr = new TransactionRepository();
            Transaction transaction = new Transaction
            {
                Iban = "FI44 1234",
                Amount = 100,
                TimeStamp = DateTime.Today
            };
            AccountRepository.AddTransaction(transaction);
            
        }
    }
}
