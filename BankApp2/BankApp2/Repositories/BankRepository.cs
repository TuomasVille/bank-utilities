using System;
using System.Collections.Generic;
using System.Text;
using BankApp2.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp2.Repositories
{
    class BankRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public Bank GetBankById(int id)
        {
            var banks = _context.Bank.FirstOrDefault(b => b.Id == id);
            return banks;
        }

        public void CreateBank(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        public void UpdateBank(int id, Bank bank)
        {
            var UpdateBank = GetBankById(id);
            if (UpdateBank != null)
            {
                UpdateBank.Name = bank.Name;
                UpdateBank.Bic = bank.Bic;
                _context.Bank.Update(UpdateBank);
            }
            _context.SaveChanges();
        }

        public void DeleteBank(int id)
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null)
            {
                _context.Bank.Remove(delBank);
                _context.SaveChanges();
            }
        }
        public List<Bank> GetTransactionsFromBanksCustomersAccounts()
        {
            using (var _context = new BankdbContext())
            {
                List<Bank> banks = _context.Bank
                         .Include(b => b.Customer)
                         .Include(b => b.Account)
                         .Include(b => b.Account).ThenInclude(a => a.Transaction)
                         .ToListAsync().Result;
                return banks;
            }
        }
    }
}
