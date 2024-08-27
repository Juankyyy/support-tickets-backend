using Microsoft.AspNetCore.Mvc;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            try 
            {
                var tickets = _ticketRepository.GetAll();
                return Ok(tickets);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los tickets: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTicket(int id)
        {
            try 
            {
                var ticket = _ticketRepository.GetById(id);

                if (ticket == null)
                {
                    return NotFound($"Ticket {id} no encontrado");
                }

                return Ok(ticket);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el ticket {id}: {ex.Message}");
            }
        }
    }
}