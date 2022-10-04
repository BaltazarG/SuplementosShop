using API.Entities;
using API.Models.CategoryModels;
using AutoMapper;

namespace API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryToCreationDto, Category>();
            CreateMap<Category, CategoryToCreationDto>();


            CreateMap<CategoryToUpdateDto, Category>();
            CreateMap<Category, CategoryToUpdateDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();


            CreateMap<Category, CategoryWithoutProductsDto>();
            CreateMap<CategoryWithoutProductsDto, Category>();
        }
    }
}
