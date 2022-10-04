using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetProducts();
        Task<Product?> GetProductById(int productId);
        Task<IEnumerable<Product?>> GetProductsByCategory(int categoryId);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int productId);
        Task<bool> AddProduct(Product product);
    }
}
