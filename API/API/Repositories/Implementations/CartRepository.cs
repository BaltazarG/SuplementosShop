using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using API.Entities;
using API.Repositories.Interfaces;
using API.Repositories.Implementations;
using API.Context;

namespace API.Repositories.Implementations
{
    public class CartRepository : Repository, ICartRepository
    {

        public CartRepository(SuplementosShopContext context) : base(context)
        {
        }

        //creo el carrito al momento del registro del usuario como cliente
        public async Task CreateCart(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId,
                CartItems = new List<CartItem>()
            };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddItem(int productId, int quantity, string username)
        {

            //traigo el carrito del usuario
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == username);

            if (cart == null)
                return false;

            //traigo un item del carrito que tenga ese producto y este en el carrito del usuario
            var cartitem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId && c.CartId == cart.Id);

            // si es null creo un nuevo item con el producto, cantidad e Id del carrito del usuario
            if (cartitem is null)
            {
                var newItem = new CartItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.Id,
                };

                await _context.CartItems.AddAsync(newItem);
                return await SaveChanges();
            }
            // pero si no es null, le sumo la cantidad al item encontrado

            cartitem.Quantity += quantity;
            return await SaveChanges();

        }

        // elimino el producto del carrito
        public async Task<bool> DeleteItem(int itemId)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == itemId);

            if (item is null)
                return false;

            _context.CartItems.Remove(item);
            return await SaveChanges();
        }


        //traigo un item por id
        public async Task<CartItem?> GetItem(int itemId)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == itemId);

            if (item is null)
                return null;
            return item;
        }


        //traigo todos los items del carrito de un usuario
        public async Task<ICollection<CartItem?>> GetItems(string userId)
        {
            var cart = await _context.Carts.Where(c => c.UserId == userId).FirstOrDefaultAsync();
            if (cart is null)
                return null;

            //incluyo la categoria
            var items = await _context.CartItems.Where(c => c.CartId == cart.Id).Include(d => d.Product).ThenInclude(g => g.Category).ToListAsync();
            return items;
        }


        //actualizo la cantidad de un item del carrito
        public async Task<bool> UpdateItem(int cartItemId, int quantity)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemId);

            if (item is null)
                return false;
            item.Quantity = quantity;

            // si la cantidad es 0 lo elimino del carrito
            if (item.Quantity <= 0)
                _context.CartItems.Remove(item);

            return await SaveChanges();
        }
    }
}
