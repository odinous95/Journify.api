using Journify.core.Entities;

namespace UserManagment.service.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(User user);
        Task<Guid> GetUserByAuthSubAsync(string authSub);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
    }
}
