using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankLibrary.Repository
{
    public class CustomerRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public void Create(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            var customers = _context.Customer.FirstOrDefault(c => c.Id == id);
            return customers;
        }

        public void Update(int id, Customer customer)
        {
            var UpdateCustomer = GetCustomerById(id);
            if(UpdateCustomer != null)
            {
                UpdateCustomer.FirstName = customer.FirstName;
                UpdateCustomer.LastName = customer.LastName;
                UpdateCustomer.BankId = customer.BankId;
                _context.Customer.Update(UpdateCustomer);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delCustomer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if(delCustomer != null)
            {
                _context.Customer.Remove(delCustomer);
                _context.SaveChanges();
            }
        }

        //public List<Customer> GetAccountsByIdAndBalance(int id)
        //{
        //    var customer = _context.Customer
        //        .Include(c => c.Account)
        //        .Single(c => c.Id == id);

        //    return customer;
        //}
    }
}
