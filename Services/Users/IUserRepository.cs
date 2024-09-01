using SupportTickets.Dtos;
using SupportTickets.Models;

namespace SupportTickets.Services
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User VerifyEmailSignup(User user);
        public User VerifyEmailLogin(LoginDTO userLogin);
        public void Create(User user);
    }
}