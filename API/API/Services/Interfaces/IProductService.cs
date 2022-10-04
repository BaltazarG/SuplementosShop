using API.Models.ProductModels;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto?>> GetProducts();
        Task<ProductDto?> GetProductById(int productId);
        Task<IEnumerable<ProductDto?>> GetProductsByCategory(int categoryId);
        Task<bool> UpdateProduct(ProductToUpdateDto product, int productId);
        Task<bool> DeleteProduct(int productId);
        Task<bool> AddProduct(ProductToCreationDto product);
    }
}
