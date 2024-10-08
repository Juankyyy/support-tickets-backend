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

        [HttpGet("user/{id}")]
        public IActionResult GetTicketsByUser(int id)
        {
            try 
            {
                var tickets = _ticketRepository.GetByUser(id);

                if (tickets.Count() == 0)
                {
                    return NotFound($"No se encontraron tickets para el usuario {id}");
                }

                return Ok(tickets);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los tickets del usuario {id}: {ex.Message}");
            }
        }

        [HttpGet("support/{id}")]
        public IActionResult GetTicketsBySupport(int id)
        {
            try 
            {
                var tickets = _ticketRepository.GetBySupport(id);

                if (tickets.Count() == 0)
                {
                    return NotFound($"No se encontraron tickets para el soporte {id}");
                }

                return Ok(tickets);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los tickets del soporte {id}: {ex.Message}");
            }
        }

        [HttpGet("support/{id}/solved")]
        public IActionResult GetSolvedTicketsBySupport(int id)
        {
            try 
            {
                var tickets = _ticketRepository.GetSolvedTicketsBySupport(id);

                if (tickets.Count() == 0)
                {
                    return NotFound($"No se encontraron tickets resueltos del soporte {id}");
                }

                return Ok(tickets);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los tickets resueltos del soporte {id}: {ex.Message}");
            }
        }

        [HttpGet("support/{id}/unsolved")]
        public IActionResult GetUnsolvedTicketsBySupport(int id)
        {
            try 
            {
                var tickets = _ticketRepository.GetUnsolvedTicketsBySupport(id);

                if (tickets.Count() == 0)
                {
                    return NotFound($"No se encontraron tickets sin resolver del soporte {id}");
                }

                return Ok(tickets);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los tickets sin resolver del soporte {id}: {ex.Message}");
            }
        }
    }
}