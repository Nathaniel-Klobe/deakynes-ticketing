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

        public void Create(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Add(employee);
        }

        public void Delete(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList<Employee>();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault<Employee>(p => p.EmployeeId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void Update(Employee employee)
        {
            //Nothing
        }

    }
}

