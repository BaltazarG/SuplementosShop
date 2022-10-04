using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category?>> GetCategories();
        Task<Category?> GetCategoryById(int categoryId);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int categoryId);
        Task<bool> AddCategory(Category category);
    }
}
