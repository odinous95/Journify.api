using Journify.core.Entities;

namespace UserManagment.service.Interfaces
{
    public interface IJwtService
    {
        /// <summary>
        /// Creates a JWT access token for the given user.
        /// </summary>
        /// <param name="user">The user to create a token for.</param>
        /// <returns>A signed JWT as a string.</returns>
        string CreateToken(User user);
    }
}
