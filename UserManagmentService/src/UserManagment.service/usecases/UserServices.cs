using Journify.core.Entities;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;


namespace UserManagment.service.usecases
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> GetUserProfileOrCreateAsync(UserCommand command)
        {
            var user = await _userRepository.GetUserByExternalIdAsync(command.ExternalIdentifyProvider);
            if (user != null)
                return user;
            var newUser = new User(
                command.ExternalIdentifyProvider,
                command.Username,
                command.Email
            );
            await _userRepository.CreateUserAsync(newUser);
            return newUser;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }


    }
}
