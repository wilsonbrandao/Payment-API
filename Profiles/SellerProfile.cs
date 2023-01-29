using AutoMapper;
using Payment_API.Data.DTOs.Seller;
using Payment_API.Models;

namespace Payment_API.Profiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<CreateSellerDto, Seller>();
            CreateMap<UpdateSellerDto, Seller>();
            CreateMap<Seller, ReadSellerDto>();
        }
    }
}
