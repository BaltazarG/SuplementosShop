using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {

        public UserRepository(SuplementosShopContext context) : base(context)
        {
        }



        public async Task<ICollection<IdentityUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
