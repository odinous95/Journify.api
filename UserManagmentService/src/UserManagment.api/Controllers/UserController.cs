using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagment.api.DTOS;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;

namespace UserManagment.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            if (request == null)
                return BadRequest("Input data is null.");

            var command = new CreateUserCommand(
                request.Email,
                request.Password
            );
            var result = await _userService.CreateUserAsync(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserDto request)
        {
            if (request == null)
                return BadRequest("Input data is null.");
            var command = new LoginUserCommand(
                request.Email,
                request.Password
            );
            var result = await _userService.LoginUserAsync(command);
            if (result == null)
                return Unauthorized("Invalid credentials.");
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null) return NotFound("No users found.");
            return Ok(users);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound("User not found.");
            return Ok(user);
        }
    }
}
