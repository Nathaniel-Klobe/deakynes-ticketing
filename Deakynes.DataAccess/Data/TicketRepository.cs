using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DeakynesContext _context;

        public TicketRepository(DeakynesContext context)
        {
            _context = context;
        }

        public void Create(Ticket ticket)
        {
            if(ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            _context.Tickets.Add(ticket);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.ToList<Ticket>();
        }

        public Ticket GetTicket(int id)
        {
            return _context.Tickets.FirstOrDefault<Ticket>(p => p.TicketId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void Update(Ticket ticket)
        {
            //Nothing
        }
    }
}
