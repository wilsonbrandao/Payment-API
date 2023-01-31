using AutoMapper;
using Payment_API.Data.DTOs.SaleDto;
using Payment_API.Models;

namespace Payment_API.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, ReadSaleDto>();
            CreateMap<CreateSaleDto, Sale>();
            CreateMap<UpdateSaleDto, Sale>();
        }
    }
}
