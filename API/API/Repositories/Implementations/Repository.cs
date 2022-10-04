using API.Context;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class Repository : IRepository
    {
        internal readonly SuplementosShopContext _context;

        public Repository(SuplementosShopContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
