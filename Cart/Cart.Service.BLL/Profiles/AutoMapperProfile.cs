using AutoMapper;
using Cart.Service.BLL.Dtos;
using Cart.Service.DAL.Entities;

namespace Cart.Service.BLL.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }
    }
}
