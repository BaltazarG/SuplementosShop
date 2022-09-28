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
        public async Task AddCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
                return;

            _context.Remove(category);
            await _context.SaveChangesAsync();
        }



        public async Task<Category?> GetCategoryById(int categoryId)
        {

            Category? category = await _context.Categories.FindAsync(categoryId);

            return category;
        }

        public async Task<ICollection<Category?>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task UpdateCategory(Category category)
        {
            var categoryToUpdate = await GetCategoryById(category.Id);


            _context.Categories.Remove(categoryToUpdate);
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();
        }
    }
}
