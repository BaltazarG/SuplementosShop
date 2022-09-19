using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public void AddItem(CartItem cartItem);
        public void UpdateItem(CartItem cartItem);
        public void DeleteItem(int itemId);

        public CartItem GetItem(int id);
        public ICollection<CartItem> GetItems(int id);
    }
}
