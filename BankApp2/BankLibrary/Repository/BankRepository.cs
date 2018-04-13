using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Repository
{
    public class BankRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        //public void Update(int id, Bank bank)
        //{
        //    var UpdateBank = GetBankById(id);
        //    if (UpdateBank != null)
        //    {
        //        UpdateBank.Name = bank.Name;
        //        UpdateBank.BIC = bank.BIC;
        //        _context.Bank.Update(UpdateBank);
        //    }
        //    _context.SaveChanges();
        //}

        public void Delete(int id)
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if(delBank != null)
            {
                _context.Bank.Remove(delBank);
                _context.SaveChanges();
            }
        }
    }
}

