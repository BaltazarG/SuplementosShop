using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<IdentityUser>> GetUsers();
        public Task<IdentityUser?> GetUser(string userId);
    }
}
