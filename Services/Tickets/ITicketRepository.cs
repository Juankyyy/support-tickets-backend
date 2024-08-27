using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAll();
    }
}