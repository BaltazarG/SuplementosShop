using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class CartRepository : Repository, ICartRepository
    {
        public CartRepository(SuplementosShopContext context) : base(context)
        {
        }
    }
}
