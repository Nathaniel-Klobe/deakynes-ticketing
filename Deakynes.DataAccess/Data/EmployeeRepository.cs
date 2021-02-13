using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DeakynesContext _context;

        public EmployeeRepository(DeakynesContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList<Employee>();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault<Employee>(p => p.EmployeeId == id);
        }
    }
}

