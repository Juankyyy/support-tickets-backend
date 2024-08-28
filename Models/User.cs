using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupportTickets.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }

        [JsonIgnore]
        public List<Ticket>? Tickets { get; set; }
    }
}