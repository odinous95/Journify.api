using Journify.core.Entities;
using Microsoft.AspNetCore.Identity;
using UserManagment.service.commands;
using UserManagment.service.Interfaces;


namespace UserManagment.service.usecases
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public UserServices(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        public async Task<Guid> CreateUserAsync(CreateUserCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Email))
                throw new ArgumentException("Email is required");

            if (string.IsNullOrWhiteSpace(command.Password))
                throw new ArgumentException("Password is required");
            User user = new();

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, command.Password);

            user.Email = command.Email;
            user.PasswordHash = hashedPassword;

            await _userRepository.CreateUserAsync(user);
            return user.Id;
        }
        public async Task<string> LoginUserAsync(LoginUserCommand command)
        {
            var user = await _userRepository.GetUserByEmailAsync(command.Email);
            if (user == null)
                return null;
            var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, command.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return null;
            var token = _jwtService.CreateToken(user);
            return token;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task<User> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
