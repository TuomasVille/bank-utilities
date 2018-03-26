using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BankApp v1.0");
            Bank bank = new Bank("Springfield Bank");

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(bank.CreateAccount(), "Homer", "Simpson"));
            customers.Add(new Customer(bank.CreateAccount(), "Bart", "Simpson"));
            customers.Add(new Customer(bank.CreateAccount(), "Marge", "Simpson"));

            Random random = new Random();
            var endTime = DateTime.Today;
            var time = new TimeSpan(24 * 30 * 6, 0, 0);
            var startTime = endTime.Date - time;

            Console.WriteLine($"Transactions from last months: {startTime.ToShortDateString()}" +
            $"-{endTime.ToShortDateString()}");

            for (int i = 0; i < 60; i++)
            {
                bank.AddTransactionForCustomer(customers[random.Next(0,3)].AccountNumber, 
                    new Transaction(random.Next(-7000, 4000), 
                    new DateTime(random.Next(2016,2019), random.Next(1,13), random.Next(1, 28))));
            }

            for(int i = 0; i < customers.Count; i++)
            {
                PrintBalance(bank, customers[i]);
                PrintTransactions(bank.GetTransactionsForCustomerForTimeSpan(customers[i].AccountNumber, startTime, endTime), customers[i]);
            }
            Console.WriteLine("<Enter> to Exit!");
            Console.ReadLine();
        }

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("{0} - balance: {1}{2:0.00}",
                customer.ToString(), balance >= 0 ? "+" : "", balance);
        }

        public static void PrintTransactions(List<Transaction> transactions, Customer customer)
        {
            Console.WriteLine($"Transactions {customer.FirstName} {customer.LastName}");

            for (int i = 0; i < transactions.Count(); i++)
            {
                Console.WriteLine("{0}\t{1}{2:0.00}",
                    transactions[i].TimeStamp.ToShortDateString(),
                    transactions[i].Sum >= 0 ? "+" : "",
                    transactions[i].Sum);
            }
            Console.WriteLine("\n");
        }
    }
}

