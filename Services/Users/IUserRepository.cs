using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
    }
}