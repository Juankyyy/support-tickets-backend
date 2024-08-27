using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAll();
        public Ticket GetById(int id);
        public void Assignment(int ticketId, int userId);
    }
}