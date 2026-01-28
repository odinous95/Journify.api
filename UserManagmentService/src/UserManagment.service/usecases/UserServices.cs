using Journify.core.Entities;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;

namespace UserManagment.service.usecases
{
    public class UserServices(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Guid> CreateUser(ProvisionUserCommand command)
        {
            // Check for existing user by AuthSub only

            if (string.IsNullOrWhiteSpace(command.AuthSub))
                throw new ArgumentException("AuthSub is required");
            var existingUserId = await _userRepository.GetUserByAuthSubAsync(command.AuthSub);
            if (existingUserId != Guid.Empty)
                return existingUserId;
            if (string.IsNullOrWhiteSpace(command.Email))
                throw new ArgumentException("Email is required");
            User user = User.Create(command.AuthSub, command.Username, command.Email, command.EmailVerified);
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id)
                ?? throw new KeyNotFoundException($"User with id {id} not found.");
        }
    }
}
