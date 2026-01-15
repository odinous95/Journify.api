using Journify.core.Entities;

namespace UserManagment.service.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
