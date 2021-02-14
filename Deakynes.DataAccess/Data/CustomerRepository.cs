using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DeakynesContext _context;

        public CustomerRepository(DeakynesContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customers.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList<Customer>();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault<Customer>(p => p.CustomerId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void Update(Customer customer)
        {
            //nothing
        }
    }
}
