using AutoMapper;
using Core.Dtos;
using Core.Dtos.BrandDto;
using Core.Dtos.CategoryDto;
using Core.Dtos.ColorDto;
using Core.Dtos.OfferDto;
using Core.Dtos.ProductDto;
using Core.Dtos.UsageStatus;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ColorDto, Color>().ReverseMap();
            CreateMap<OfferDto, Offer>().ReverseMap();
            CreateMap<OffersUsersProductsDto, Product>().ReverseMap();
            CreateMap<UserRegisterDto, User>();
            CreateMap<PostCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<PostColorDto, Color>();
            CreateMap<PostBrandDto, Brand>();
            CreateMap<PostUsageStatusDto, UsageStatus>();
            CreateMap<PostOfferDto, Offer>();
            CreateMap<PostProductDto, Product>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<UsageStatusDto, UsageStatus>().ReverseMap();
            /*
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
           
            CreateMap<UserLoginDto, User>();
            */
        }
    }
}
