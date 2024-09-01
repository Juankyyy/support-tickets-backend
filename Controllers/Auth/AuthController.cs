using Microsoft.AspNetCore.Mvc;
using SupportTickets.Dtos;
using SupportTickets.Models;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Auth(LoginDTO userLogin)
        {
            try 
            {
                var user = _userRepository.VerifyEmailLogin(userLogin);

                if (user == null)
                {
                    return Unauthorized(new { error = "Email incorrecto" });
                }

                if (user.Password != userLogin.Password)
                {
                    return Unauthorized(new { error = "Password incorrecta" });
                }

                return Ok(user);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al autenticar al usuario: {ex.Message}");
            }
        }
    }
}