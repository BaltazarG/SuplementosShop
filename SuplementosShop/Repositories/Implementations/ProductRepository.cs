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
            IEnumerable<Product>? products = await _context.Products.Include(c => c.Category).OrderBy(c => c.Name).ToListAsync();

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

            if (productToUpdate is null)
                return;

            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Category = product.Category;
            productToUpdate.ImageUrl = product.ImageUrl;
            productToUpdate.Price = product.Price;


            await _context.SaveChangesAsync();
        }
    }
}
