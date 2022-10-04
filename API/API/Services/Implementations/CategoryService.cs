using API.Entities;
using API.Models.CategoryModels;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _mapper = mapper;
            _CategoryRepository = CategoryRepository;
        }

        public async Task<bool> AddCategory(CategoryToCreationDto category)
        {
            var mapped = _mapper.Map<Category>(category);

            return await _CategoryRepository.AddCategory(mapped);
        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            return await _CategoryRepository.DeleteCategory(CategoryId);
        }

        public async Task<CategoryDto?> GetCategoryById(int CategoryId)
        {
            var Category = await _CategoryRepository.GetCategoryById(CategoryId);


            return _mapper.Map<CategoryDto>(Category);
        }

        public async Task<IEnumerable<CategoryDto?>> GetCategories()
        {
            var Categorys = await _CategoryRepository.GetCategories();
            return _mapper.Map<ICollection<CategoryDto>>(Categorys);
        }


        public async Task<bool> UpdateCategory(CategoryToUpdateDto Category, int categoryId)
        {
            var mapped = _mapper.Map<Category>(Category);

            mapped.Id = categoryId;

            return await _CategoryRepository.UpdateCategory(mapped);

        }
    }
}