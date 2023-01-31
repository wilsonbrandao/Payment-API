using AutoMapper;
using Payment_API.Data.DTOs.ProductDto;
using Payment_API.Models;

namespace Payment_API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ReadProductDto>();
        }
    }
}
