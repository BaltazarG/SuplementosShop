using SuplementosShop.Entities;

namespace SuplementosShop.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        void AddCategory(Category category);
    }
}
