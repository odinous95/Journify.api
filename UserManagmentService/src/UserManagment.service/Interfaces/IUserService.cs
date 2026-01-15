using Journify.core.Entities;
using UserManagment.service.commands;

namespace UserManagment.service.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(CreateUserCommand command);
        Task<string> LoginUserAsync(LoginUserCommand command);

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
