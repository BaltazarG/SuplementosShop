using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task CreateCart(string userId);
        public Task AddItem(int productId, int quantity, string userId);
        public Task UpdateItem(int cartItemId, int quantity);
        public Task DeleteItem(int itemId);

        public Task<CartItem?> GetItem(int id);
        public Task<ICollection<CartItem?>> GetItems(string userId);
    }
}
