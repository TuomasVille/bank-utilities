using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Customer
    {
        //Fields
        private string _accountNumber;
        private string _firstName;
        private string _lastName;

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }

        //Constructors
        public Customer(string accountNumber, string firstName, string lastName)
        {
            AccountNumber = accountNumber;
            _firstName = firstName;
            _lastName = lastName;
        }

        public Customer(string accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}\t{_accountNumber}";
        }
    }
}
