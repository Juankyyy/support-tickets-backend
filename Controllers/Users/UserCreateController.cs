using Microsoft.AspNetCore.Mvc;
using SupportTickets.Models;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UserCreateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserCreateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try 
            {
                if (user == null)
                {
                    return BadRequest("No puede haber datos nulos");
                }

                var emailExists = _userRepository.VerifyEmailSignup(user);
                if (emailExists != null)
                {
                    return BadRequest(new { error = "Email en uso"});
                }

                _userRepository.Create(user);

                return Ok("Usuario creado correctamente");

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear usuario: {ex.Message}");
            }
        }
    }
}