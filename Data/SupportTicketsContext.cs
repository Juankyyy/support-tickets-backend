using Microsoft.EntityFrameworkCore;
using SupportTickets.Models;

namespace SupportTickets.Data
{
    public class SupportTicketsContext : DbContext
    {
        public SupportTicketsContext(DbContextOptions<SupportTicketsContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}