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

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _context.Products.Add(product);

            _context.SaveChanges();

        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product == null)
                return;

            _context.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            Product? product = _context.Products.Find(productId);

            return product;
        }

        public ICollection<Product> GetProducts()
        {
            ICollection<Product>? products = _context.Products.Include(c => c.Category).ToList();

            return products;
        }

        public ICollection<Product> GetProductsByCategory(int categoryId)
        {
            ICollection<Product>? products = _context.Products.Where(p => p.CategoryId == categoryId).ToList();

            return products;
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.Id);


            _context.Products.Remove(productToUpdate);
            _context.Products.Add(product);

            _context.SaveChanges();
        }
    }
}
