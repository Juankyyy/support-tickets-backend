using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAll();
        public Ticket GetById(int id);
    }
}