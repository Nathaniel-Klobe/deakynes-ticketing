using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public interface ITicketRepository
    {
        bool SaveChanges();

        IEnumerable<Ticket> GetAll();

        Ticket GetTicket(int id);

        void Create(Ticket ticket);

        void Update(Ticket ticket);

        void Delete(Ticket ticket);
    }
}
