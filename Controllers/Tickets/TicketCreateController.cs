using Microsoft.AspNetCore.Mvc;
using SupportTickets.Models;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/Tickets")]

    public class TicketCreateController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketCreateController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpPost]
        public IActionResult CreateTicket(Ticket ticket)
        {
            try 
            {
                if (ticket == null)
                {
                    return BadRequest("No puede haber datos nulos");
                }

                _ticketRepository.Create(ticket);

                return Ok("Ticket creado correctamente");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear ticket: {ex.Message}");
            }
        }
    }
}