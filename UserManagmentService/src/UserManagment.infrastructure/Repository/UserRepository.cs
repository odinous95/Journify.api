using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;
using UserManagment.infrastructure.Data;
using UserManagment.service.Interfaces;

namespace UserManagment.infrastructure.Repository
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        private readonly AppDbContext _appDbcontext = appDbContext;

        public async Task<Guid> CreateUserAsync(User user)
        {
            _appDbcontext.Users.Add(user);
            await _appDbcontext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbcontext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _appDbcontext.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _appDbcontext.Users.Update(user);
            await _appDbcontext.SaveChangesAsync();
            return user;
        }
    }
}
