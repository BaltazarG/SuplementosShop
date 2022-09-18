using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuplementosShop.Areas.Identity.Data;
using SuplementosShop.Entities;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Repositories.Implementations
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(SuplementosShopContext context) : base(context)
        {

        }

        public void AddCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _context.Categories.Add(category);

            _context.SaveChanges();

        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);

            if (category == null)
                return;

            _context.Remove(category);
            _context.SaveChanges();
        }

        public Category GetCategoryById(int categoryId)
        {

            Category? category = _context.Categories.Find(categoryId);

            return category;
        }

        public ICollection<Category> GetCategories()
        {
            ICollection<Category>? categories = _context.Categories.ToList();

            return categories;
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.Id);


            _context.Categories.Remove(categoryToUpdate);
            _context.Categories.Add(category);

            _context.SaveChanges();
        }
    }
}
