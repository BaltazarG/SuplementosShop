using Microsoft.AspNetCore.Identity;

namespace API.Services.Interfaces
{
    public interface IJwtGeneratorService
    {
        public string? GenerateAuthToken(IdentityUser user, ICollection<string> roles);
    }
}
