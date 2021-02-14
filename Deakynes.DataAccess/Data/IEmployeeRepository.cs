using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public interface IEmployeeRepository
    {
        bool SaveChanges();

        IEnumerable<Employee> GetAll();

        Employee GetEmployee(int id);

        void Create(Employee employee);

        void Update(Employee employee);

        void Delete(Employee employee);
    }
}
