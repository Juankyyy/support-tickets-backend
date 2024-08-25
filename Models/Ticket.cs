using System.ComponentModel.DataAnnotations;

namespace SupportTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public int AssigneeId { get; set; }
        // public User? Assignee { get; set; }
        
        [Required]
        public int ReporterId { get; set; }
        public User? Reporter { get; set; }
    }
}