using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Repositories.Interfaces;
using API.Context;

namespace API.Repositories.Implementations
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(SuplementosShopContext context) : base(context)
        {
        }

        public async Task<bool> AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            await _context.Products.AddAsync(product);

            return await SaveChanges();

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                return false;

            _context.Remove(product);

            return await SaveChanges();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            Product? product = await _context.Products.FindAsync(productId);

            return product;
        }

        public async Task<IEnumerable<Product?>> GetProducts()
        {
            IEnumerable<Product>? products = await _context.Products.OrderBy(c => c.Name).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product?>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<Product?> products = await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();

            return products;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var productToUpdate = await GetProductById(product.Id);

            if (productToUpdate is null)
                return false;

            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Category = product.Category;
            productToUpdate.ImageUrl = product.ImageUrl;
            productToUpdate.Price = product.Price;


            return await SaveChanges();
        }
    }
}
