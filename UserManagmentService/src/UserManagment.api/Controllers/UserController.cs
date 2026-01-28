using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;

namespace UserManagment.api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticatedUserProvider _authenticatedUserProvider;
        public UserController(IUserService userService, IAuthenticatedUserProvider authenticatedUserProvider)
        {
            _userService = userService;
            _authenticatedUserProvider = authenticatedUserProvider;
        }

        [HttpGet("ping")]
        public ActionResult Ping()
        {
            return Ok("User Service is alive");
        }
        [Authorize]
        [HttpGet("secure")]
        public ActionResult Secure()
        {
            Console.WriteLine(User);

            return Ok("Claims logged");
        }


        [HttpGet("profile")]
        public async Task<ActionResult> GetUserProfileOrCreate()
        {
            var userProvided = _authenticatedUserProvider.GetCurrentUser();
            var command = new UserCommand(
                userProvided.ExternalIdentityId,
                userProvided.Name,
                userProvided.Email
            );

            var user = await _userService.GetUserProfileOrCreateAsync(command);
            return Ok(user);
        }
    }
}
