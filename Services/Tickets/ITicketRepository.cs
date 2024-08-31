using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAll();
        public Ticket GetById(int id);
        public void Create(Ticket ticket);
        public void Update(Ticket ticket);
        public void Assignment(int ticketId, int userId);
        public void SolvedTicket(Ticket ticket);
        public void UnsolvedTicket(Ticket ticket);
        public IEnumerable<Ticket> GetBySupport(int id);
        public IEnumerable<Ticket> GetByUser(int id);
        public IEnumerable<Ticket> GetSolvedTicketsBySupport(int id);
        public IEnumerable<Ticket> GetUnsolvedTicketsBySupport(int id);
    }
}