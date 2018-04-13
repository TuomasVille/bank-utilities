using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Repository
{
    public class AccountRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public void Create(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }

        public List<Account> Get()
        {
            List<Account> accounts = _context.Account.ToListAsync().Result;
            return accounts;
        }

        public Account GetAccountByIban(string iban)
        {
            var account = _context.Account.FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
        }
    }
}
