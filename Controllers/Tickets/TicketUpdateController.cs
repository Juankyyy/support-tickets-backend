using Microsoft.AspNetCore.Mvc;
using SupportTickets.Models;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/Tickets")]

    public class TicketUpdateController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketUpdateController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(Ticket ticket)
        {
            try 
            {
                if (ticket == null)
                {
                    return BadRequest("No puede haber datos nulos");
                }

                _ticketRepository.Update(ticket);

                return Ok($"Ticket {ticket.Id} actualizado correctamente");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar ticket: {ex.Message}");
            }
        }
    }
}