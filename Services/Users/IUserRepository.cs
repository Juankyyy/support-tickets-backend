using SupportTickets.Dtos;
using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User Auth(LoginDTO userLogin);
    }
}