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

        public User VerifyEmailSignup(User user)
        {
            var userExists = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            return userExists;
        }

        public User VerifyEmailLogin(LoginDTO userLogin)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userLogin.Email);

            return user;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}