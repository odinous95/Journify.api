using Microsoft.AspNetCore.Mvc;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;

namespace UserManagment.api.Controllers
{
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


        [HttpGet("profile")]
        public async Task<ActionResult> GetUserProfileOrCreate()
        {
            var userProvided = _authenticatedUserProvider.GetCurrentUser();
            var command = new UserCommand(
                userProvided.ExternalIdentityId,
                userProvided.Name,
                userProvided.Email,
                userProvided.Role
            );

            var user = await _userService.GetUserProfileOrCreateAsync(command);
            return Ok(user);
        }
    }
}
