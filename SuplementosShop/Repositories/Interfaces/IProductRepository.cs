using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int productId);
        ICollection<Product> GetProductsByCategory(int categoryId);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        void AddProduct(Product product);
    }
}
