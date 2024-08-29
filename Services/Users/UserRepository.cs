using Microsoft.EntityFrameworkCore;
using SupportTickets.Data;
using SupportTickets.Dtos;
using SupportTickets.Models;

namespace SupportTickets.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly SupportTicketsContext _context;

        public UserRepository(SupportTicketsContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Auth(LoginDTO userLogin)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userLogin.Email && u.Password == userLogin.Password);

            return user;
        }
    }
}