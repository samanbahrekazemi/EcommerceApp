using AutoMapper;
using EcommerceApp.Application.Features.Product.Commands;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Events.Product;
using EcommerceApp.Shared.DTOs;

namespace EcommerceApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(src => src.CategoryId, opt => opt.MapFrom(x => x.CategoryId.Value))
                .ReverseMap();


            CreateMap<ProductDto, CreateProductCommand>().ReverseMap();

            CreateMap<ProductDto, ProductCreatedEvent>()
              .ForMember(dest => dest.ProductDto, opt => opt.MapFrom(src => src));

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ReverseMap();
        }
    }
}
