using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    class Bank
    {
        //Fields
        private List<Account> _accounts;
        private string _name;

        //Constructors
        public Bank(string name)
        {
            _name = name;
            _accounts = new List<Account>();
        }

        public Bank(List<Account> accounts, string name)
        {
            _accounts = accounts;
            _name = name;
        }

        //Methods
        public bool  AddTransactionForCustomer(string accountNumber, Transaction transaction)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).First().AddTransaction(transaction);
        }


        public string CreateAccount()
        {
            Random rnd = new Random();
            string rndAccount = "FI";
            for(int i = 0; i < 16; i++)
            {
                rndAccount += rnd.Next(0,10);
            }
            _accounts.Add(new Account(rndAccount));
            return rndAccount;
        }

        public double GetBalanceForCustomer(string accountNumber)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().Balance;
        }

        public List<Transaction> GetTransactionsForCustomerForTimeSpan(string accountNumber, DateTime startTime, DateTime endTime)
        {
            return (from account in _accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().GetTransactionForTimeSpan(startTime, endTime);

        }

    }
}
