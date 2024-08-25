using Microsoft.AspNetCore.Mvc;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UsersControllers : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersControllers(IUserRepository userRepository)
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