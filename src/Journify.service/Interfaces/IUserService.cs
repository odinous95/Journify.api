using Journify.core.Entities;

namespace Journify.service.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserById(Guid id);
    }
}
