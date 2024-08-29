using System.ComponentModel.DataAnnotations;

namespace SupportTickets.Dtos
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}