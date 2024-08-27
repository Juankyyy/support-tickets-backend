using Microsoft.AspNetCore.Mvc;
using SupportTickets.Models;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/tickets")]

    public class TicketAssigneeController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;

        public TicketAssigneeController(ITicketRepository ticketRepository, IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }

        [HttpPut("{ticketId}/assignee/{userId}")]
        public IActionResult GetAssignee(int ticketId, int userId)
        {
            try 
            {
                var user = _userRepository.GetById(userId);

                if (user.Role != "Support")
                {
                    return BadRequest($"El usuario con id {userId} no tiene permisos para asignar tickets");
                }

                _ticketRepository.Assignment(ticketId, userId);

                return Ok($"ticket asignado al usuario con id: {userId}");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al asignar ticket {ticketId}: {ex.Message}");
            }
        }
    }
}