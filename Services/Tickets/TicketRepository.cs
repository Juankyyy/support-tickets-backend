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

        public IEnumerable<Ticket> GetByUser(int id)
        {
            return _context.Tickets.Include(t => t.Assignee).Include(t => t.Reporter).Where(t => t.ReporterId == id).ToList();
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.Include(t => t.Assignee).Include(t => t.Reporter).FirstOrDefault(t => t.Id == id);
        }

        public void Assignment(int ticketId, int userId)
        {
            var ticket = _context.Tickets.Find(ticketId);

            ticket.AssigneeId = userId;

            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    }
}