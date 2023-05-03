using AutoMapper;
using EcommerceApp.Domain.Entities;
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

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
