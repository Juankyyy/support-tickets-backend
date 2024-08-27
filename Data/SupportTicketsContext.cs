using Microsoft.EntityFrameworkCore;
using SupportTickets.Models;

namespace SupportTickets.Data
{
    public class SupportTicketsContext : DbContext
    {
        public SupportTicketsContext(DbContextOptions<SupportTicketsContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Ticket y Assignee
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Assignee)
                .WithMany(u => u.Tickets) // asumiendo que un User puede tener varios Tickets asignados
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict); // Previene eliminación en cascada

            // Configuración de la relación entre Ticket y Reporter
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Reporter)
                .WithMany() // No necesitas una colección en User para los tickets reportados
                .HasForeignKey(t => t.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}