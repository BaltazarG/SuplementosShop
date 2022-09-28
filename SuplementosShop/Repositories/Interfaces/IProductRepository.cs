using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetProducts();
        Task<Product?> GetProductById(int productId);
        Task<IEnumerable<Product?>> GetProductsByCategory(int categoryId);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        Task AddProduct(Product product);
    }
}
