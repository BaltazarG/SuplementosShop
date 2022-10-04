using AutoMapper;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Repositories.Interfaces;
using API.Context;

namespace API.Repositories.Implementations
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(SuplementosShopContext context) : base(context)
        {

        }
        public async Task<bool> AddCategory(Category category)
        {
            if (category == null)
                return false;

            await _context.Categories.AddAsync(category);

            return await SaveChanges();

        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
                return false; ;

            _context.Remove(category);
            return await SaveChanges();
        }



        public async Task<Category?> GetCategoryById(int categoryId)
        {

            Category? category = await _context.Categories.FindAsync(categoryId);

            return category;
        }

        public async Task<ICollection<Category?>> GetCategories()
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();


            return categories;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var categoryToUpdate = await GetCategoryById(category.Id);

            if (categoryToUpdate is null)
                return false; ;

            categoryToUpdate.ShortDescription = category.ShortDescription;
            categoryToUpdate.Name = categoryToUpdate.Name;

            return await SaveChanges();
        }
    }
}
