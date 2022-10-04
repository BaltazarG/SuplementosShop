using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category?>> GetCategories();
        Task<Category?> GetCategoryById(int categoryId);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task AddCategory(Category category);
    }
}
