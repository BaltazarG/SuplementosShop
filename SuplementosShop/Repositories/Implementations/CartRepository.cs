using Microsoft.EntityFrameworkCore;
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

        public void CreateCart(string userId)
        {
            var cart = new Cart()
            {
                UserId = userId,
                CartItems = new List<CartItem>()
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void AddItem(int productId, int quantity, string userId)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (cart == null || product == null)
                return;

            var newItem = new CartItem()
            {
                ProductId = productId,
                //Product = product,
                Quantity = quantity,
                CartId = cart.Id,
                //Cart = cart
            };

            //var item = _context.CartItems.FirstOrDefault(c => c.Id == cartItem.Id);

            //if (item is null)
            //{
            //    _context.CartItems.Add(cartItem);
            //    _context.SaveChanges();
            //    return;
            //}

            //item.Quantity += cartItem.Quantity;



            _context.CartItems.Add(newItem);
            _context.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.Id == itemId);

            if (item is null)
                return;

            _context.CartItems.Remove(item);
            _context.SaveChanges();
        }

        public CartItem GetItem(int itemId)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.Id == itemId);

            if (item is null)
                return null;
            return item;
        }

        public ICollection<CartItem> GetItems(string userId)
        {
            var cart = _context.Carts.Where(c => c.UserId == userId).FirstOrDefault();
            if (cart is null)
                return null;

            var items = _context.CartItems.Where(c => c.CartId == cart.Id).Include(d => d.Product).ThenInclude(g => g.Category).ToList();
            return items;
        }

        public void UpdateItem(CartItem cartItem)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.Id == cartItem.Id);

            if (item is null)
                return;

            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }
    }
}
