using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Dtos
{
    public class TicketReadDto
    {
        public int TicketId { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string CreatedDate { get; set; }

        public string PromisedDate { get; set; }

        public string RepairType { get; set; }
    }
}
