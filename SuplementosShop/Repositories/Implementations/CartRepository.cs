using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Entities;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class CartRepository : Repository, ICartRepository
    {
        public CartRepository(SuplementosShopContext context) : base(context)
        {
        }

        public void AddItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public CartItem GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<CartItem> GetItems(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
