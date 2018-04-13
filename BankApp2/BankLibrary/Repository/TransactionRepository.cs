using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Model;
using System.Linq;

namespace BankLibrary.Repository
{
    public class TransactionRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public void Create(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
        }

        public Transaction GetTransactionById(int id)
        {
            var transactions = _context.Transaction.FirstOrDefault(t => t.Id == id);
            return transactions;
        }
    }
}
