using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagment.api.DTOS;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;

namespace UserManagment.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                message = "Authorized",
                claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

        [HttpPost]
        [Route("provision-user")]
        public async Task<ActionResult> CreateUser([FromBody] AuthenticatedUserDTO request)
        {
            var command = new ProvisionUserCommand(request.Sub, request.Name, request.Email, request.EmailVerified);
            var result = await _userService.CreateUser(command);
            return Ok(result);
        }


    }
}
