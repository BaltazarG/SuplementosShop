using Microsoft.AspNetCore.Identity;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<IdentityUser>> GetUsers();
    }
}
