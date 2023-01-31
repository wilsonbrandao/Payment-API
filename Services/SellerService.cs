using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Payment_API.Data;
using Payment_API.Data.DTOs.SellerDto;
using Payment_API.Models;

namespace Payment_API.Services
{
    public class SellerService
    {
        private readonly PaymentApiContext _context;
        private readonly IMapper _mapper;

        public SellerService(PaymentApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<ReadSellerDto> GetSellers()
        {
            List<Seller> sellers = _context.Sellers.ToList();
            List<ReadSellerDto> ListReadSellerDto = _mapper.Map<List<ReadSellerDto>>(sellers);
            return ListReadSellerDto;
        }

        public ReadSellerDto GetSellerById(int id)
        {
            Seller seller = _context.Sellers.Where(seller => seller.Id == id).FirstOrDefault();
            if (seller == null) return null;
            ReadSellerDto readSellerDto = _mapper.Map<ReadSellerDto>(seller);
            return readSellerDto;
        }

        public ReadSellerDto RegisterSeller(CreateSellerDto createSellerDto)
        {
            Seller seller = _mapper.Map<Seller>(createSellerDto);

            _context.Sellers.Add(seller);
            _context.SaveChanges();

            return _mapper.Map<ReadSellerDto>(seller);
        }

        public Result UpdateSeller(int id, UpdateSellerDto updateSellerDto)
        {
            Seller sellerDatabase = _context.Sellers.Where(sellerQuery => sellerQuery.Id == id).FirstOrDefault();
            if (sellerDatabase == null) return Result.Fail("Seller not found");

            sellerDatabase = _mapper.Map(updateSellerDto, sellerDatabase);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result DeleteSeller(int id)
        {
            Seller seller = _context.Sellers.Where(seller => seller.Id == id).FirstOrDefault();
            if (seller == null) return Result.Fail("seller not found");

            _context.Sellers.Remove(seller);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
