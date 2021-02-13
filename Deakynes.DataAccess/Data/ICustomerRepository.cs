using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer GetCustomer(int id);
    }
}
