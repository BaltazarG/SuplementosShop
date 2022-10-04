using API.Models.CartModels;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;

        public CartService(IMapper mapper, ICartRepository cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }
        public async Task<bool> AddItem(CartItemToCreationDto newItem, string userId)
        {

            return await _cartRepository.AddItem(newItem.ProductId, newItem.Quantity, userId);
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            return await _cartRepository.DeleteItem(itemId);
        }

        public async Task<CartItemDto?> GetItem(int id)
        {
            var item = await _cartRepository.GetItem(id);
            return _mapper.Map<CartItemDto>(item);
        }

        public async Task<ICollection<CartItemDto?>> GetItems(string userId)
        {
            var items = await _cartRepository.GetItems(userId);

            return _mapper.Map<ICollection<CartItemDto?>>(items);
        }

        public async Task<bool> UpdateItem(int cartItemId, int quantity)
        {
            return await _cartRepository.UpdateItem(cartItemId, quantity);
        }
    }
}
