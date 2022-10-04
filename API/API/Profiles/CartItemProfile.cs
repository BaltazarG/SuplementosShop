using API.Entities;
using API.Models.CartModels;
using AutoMapper;

namespace API.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItemToCreationDto, CartItem>();
            CreateMap<CartItem, CartItemToCreationDto>();


            CreateMap<CartItemToUpdateDto, CartItem>();
            CreateMap<CartItem, CartItemToUpdateDto>();

            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();
        }
    }
}
