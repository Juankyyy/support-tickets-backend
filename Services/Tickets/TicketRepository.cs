using Microsoft.EntityFrameworkCore;
using SupportTickets.Data;
using SupportTickets.Models;

namespace SupportTickets.Services
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SupportTicketsContext _context;

        public TicketRepository(SupportTicketsContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.Include(t => t.Assignee).Include(t => t.Reporter).ToList();
        }
    }
}