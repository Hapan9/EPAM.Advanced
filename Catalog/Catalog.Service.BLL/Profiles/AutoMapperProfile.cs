using AutoMapper;
using Catalog.Service.BLL.Dto;
using Catalog.Service.DAL.Enteties;
using Catalog.Service.DAL.Entities;

namespace Catalog.Service.BLL.Profiles
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ReverseMap();

            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }
    }
}
