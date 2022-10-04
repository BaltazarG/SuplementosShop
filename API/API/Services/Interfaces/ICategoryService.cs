using API.Models.CategoryModels;

namespace API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto?>> GetCategories();
        Task<CategoryDto?> GetCategoryById(int CategoryId);
        Task<bool> UpdateCategory(CategoryToUpdateDto Category, int categoryId);
        Task<bool> DeleteCategory(int CategoryId);
        Task<bool> AddCategory(CategoryToCreationDto Category);
    }
}
