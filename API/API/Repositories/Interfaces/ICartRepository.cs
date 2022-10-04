using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task CreateCart(string userId);
        public Task<bool> AddItem(int productId, int quantity, string userId);
        public Task<bool> UpdateItem(int cartItemId, int quantity);
        public Task<bool> DeleteItem(int itemId);

        public Task<CartItem?> GetItem(int id);
        public Task<ICollection<CartItem?>> GetItems(string userId);
    }
}
