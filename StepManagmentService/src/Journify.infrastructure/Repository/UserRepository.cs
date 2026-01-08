using Journify.core.Entities;
using Journify.infrastructure.Data;
using Journify.service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Journify.infrastructure.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbcontext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _appDbcontext.Users.Add(user);
            await _appDbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbcontext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _appDbcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
