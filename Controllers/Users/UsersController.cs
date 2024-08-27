using Microsoft.AspNetCore.Mvc;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try 
            {
                var users = _userRepository.GetAll();
                return Ok(users);

            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los usuarios: {ex.Message}");
            }
        }
    }
}