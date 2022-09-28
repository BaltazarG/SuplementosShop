using Microsoft.EntityFrameworkCore;
using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Entities;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(SuplementosShopContext context) : base(context)
        {
        }

        public async Task AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                return;

            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            Product? product = await _context.Products.FindAsync(productId);

            return product;
        }

        public async Task<IEnumerable<Product?>> GetProducts()
        {
            IEnumerable<Product>? products = await _context.Products.Include(c => c.Category).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product?>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<Product?> products = await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();

            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            var productToUpdate = await GetProductById(product.Id);


            _context.Products.Remove(productToUpdate);
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
        }
    }
}
