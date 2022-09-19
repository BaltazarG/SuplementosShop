using Microsoft.AspNetCore.Identity;
using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(SuplementosShopContext context) : base(context)
        {
        }

        public ICollection<IdentityUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
