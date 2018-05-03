using System;
using System.Collections.Generic;
using System.Text;
using BankApp2.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp2.Repositories
{
    class CustomerRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        public List<Customer> Get()
        {
            List<Customer> customers = _context.Customer.ToListAsync().Result;
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            var customers = _context.Customer.FirstOrDefault(c => c.Id == id);
            return customers;
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var UpdateCustomer = GetCustomerById(id);
            if (UpdateCustomer != null)
            {
                UpdateCustomer.FirstName = customer.FirstName;
                UpdateCustomer.LastName = customer.LastName;
                UpdateCustomer.BankId = customer.BankId;
                _context.Customer.Update(UpdateCustomer);
            }
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var delCustomer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (delCustomer != null)
            {
                _context.Customer.Remove(delCustomer);
                _context.SaveChanges();
            }
        }

        public List<Customer> GetAccountsByIdAndBalance(int id)
        {
            List<Customer> customer = _context.Customer
                .Include(c => c.Account)
                .Where(c => c.Id == id)
                .ToListAsync().Result;

            return customer;
        }
    }
}
