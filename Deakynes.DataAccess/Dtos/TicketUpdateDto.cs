using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Dtos
{
    public class TicketUpdateDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Description { get; set; }

        public string Details { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        public string PromisedDate { get; set; }

        [Required]
        public string RepairType { get; set; }
    }
}
