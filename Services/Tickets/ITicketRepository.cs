using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAll();
        public IEnumerable<Ticket> GetByUser(int id);
        public Ticket GetById(int id);
        public void Assignment(int ticketId, int userId);
        public void Create(Ticket ticket);
        public void Update(Ticket ticket);
    }
}