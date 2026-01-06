using Journify.core.Entities;
using Journify.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Journify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users is null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }
            var createdUser = await _userService.AddUserAsync(user);
            return createdUser;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }
    }
}
