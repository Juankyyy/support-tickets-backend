using Microsoft.AspNetCore.Mvc;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/tickets/status")]
    public class TicketStatusController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketStatusController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpPut("solved/{id}")]
        public IActionResult SolvedTicket(int id)
        {
            try 
            {
                var ticket = _ticketRepository.GetById(id);

                if (ticket == null)
                {
                    return NotFound($"Ticket {id} no encontrado");
                }
                
                if (ticket.Response == null)
                {
                    return BadRequest($"No se puede resolver un ticket sin respuesta");
                }

                _ticketRepository.SolvedTicket(ticket);
                return Ok($"Ticket {id} resuelto");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al resolver el ticket {id}: {ex.Message}");
            }
        }

        [HttpPut("unsolved/{id}")]
        public IActionResult UnsolvedTicket(int id)
        {
            try 
            {
                var ticket = _ticketRepository.GetById(id);

                if (ticket == null)
                {
                    return NotFound($"Ticket {id} no encontrado");
                }

                _ticketRepository.UnsolvedTicket(ticket);
                return Ok($"Ticket {id} sin resolver");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al deshacer el ticket resuelto {id}: {ex.Message}");
            }
        }
    }
}