using AutoMapper;
using RelatedChallange.Application.Responses;
using RelatedChallange.Core.Entities;

namespace RelatedChallange.Application.Mapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Tag, TagModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
