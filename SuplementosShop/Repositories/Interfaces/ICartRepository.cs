using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public void CreateCart(string userId);
        public void AddItem(int productId, int quantity, string userId);
        public void UpdateItem(CartItem cartItem);
        public void DeleteItem(int itemId);

        public CartItem GetItem(int id);
        public ICollection<CartItem> GetItems(string userId);
    }
}
