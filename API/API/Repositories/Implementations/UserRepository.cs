using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API.Repositories.Interfaces;
using API.Context;

namespace API.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {

        public UserRepository(SuplementosShopContext context) : base(context)
        {
        }

        public async Task<IdentityUser?> GetUser(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<ICollection<IdentityUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
