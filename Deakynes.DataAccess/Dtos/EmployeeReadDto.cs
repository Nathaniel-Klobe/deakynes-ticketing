using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Dtos
{
    public class EmployeeReadDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AccessLevel { get; set; }
    }
}
