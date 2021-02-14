using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public interface ICustomerRepository
    {
        bool SaveChanges();

        IEnumerable<Customer> GetAll();

        Customer GetCustomer(int id);

        void Create(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);
    }
}
