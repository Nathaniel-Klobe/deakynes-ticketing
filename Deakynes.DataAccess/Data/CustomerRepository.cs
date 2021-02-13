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

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList<Customer>();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault<Customer>(p => p.CustomerId == id);
        }
    }
}
