using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class Repository : IRepository
    {
        internal readonly SuplementosShopContext _context;

        public Repository(SuplementosShopContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
