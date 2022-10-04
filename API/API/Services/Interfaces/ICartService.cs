using API.Models.CartModels;

namespace API.Services.Interfaces
{
    public interface ICartService
    {
        public Task<bool> AddItem(CartItemToCreationDto newItem, string userId);
        public Task<bool> UpdateItem(int cartItemId, int quantity);
        public Task<bool> DeleteItem(int itemId);

        public Task<CartItemDto?> GetItem(int id);
        public Task<ICollection<CartItemDto?>> GetItems(string userId);
    }
}
