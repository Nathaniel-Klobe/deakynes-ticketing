using Deakynes.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public class DeakynesContext :DbContext
    {
        public DeakynesContext(DbContextOptions<DeakynesContext> opt) : base(opt)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
