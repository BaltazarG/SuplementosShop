using API.Entities;
using API.Models.ProductModels;
using AutoMapper;

namespace API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductToCreationDto, Product>();
            CreateMap<Product, ProductToCreationDto>();


            CreateMap<ProductToUpdateDto, Product>();
            CreateMap<Product, ProductToUpdateDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithoutCategoryDto>();
            CreateMap<ProductWithoutCategoryDto, Product>();
        }
    }
}
