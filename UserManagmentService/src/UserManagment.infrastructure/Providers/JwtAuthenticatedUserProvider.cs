using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using UserManagment.service.Interfaces;
using UserManagment.Service.DTOs;

namespace UserManagment.infrastructure.Providers
{
    public sealed class JwtAuthenticatedUserProvider : IAuthenticatedUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtAuthenticatedUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public AuthenticatedUserDto GetCurrentUser()
        {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new UnauthorizedAccessException("HTTP context is not available.");
            Console.WriteLine(httpContext);
            var user = httpContext.User;
            Console.WriteLine(user);
            var identity = user.Identity;

            if (identity == null)
            {
                throw new UnauthorizedAccessException("User identity is not available.");
            }

            if (!identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            foreach (var claim in user.Claims)
            {
                Console.WriteLine($"{claim.Type} = {claim.Value}");
            }

            var externalIdentityId = user.FindFirst("sub")?.Value ?? throw new UnauthorizedAccessException("User external identity ID is not available.");
            var email = user.FindFirst("email")?.Value ?? string.Empty;
            var name = user.FindFirst("name")?.Value ?? string.Empty;
            var role = user.FindFirst(ClaimTypes.Role)?.Value ?? user.FindFirst("roles")?.Value ?? "User";
            return new AuthenticatedUserDto(
               externalIdentityId,
               email,
               name,
               role
            );
        }
    }
}
