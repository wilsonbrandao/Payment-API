using AutoMapper;
using FluentResults;
using Payment_API.Data;
using Payment_API.Data.DTOs.SaleDto;
using Payment_API.Models;

namespace Payment_API.Services
{
    public class SaleService
    {
        private readonly PaymentApiContext _context;
        private readonly IMapper _mapper;

        public SaleService(PaymentApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadSaleDto> GetSales()
        {
            List<Sale> saleDatabase = _context.Sales.ToList();
            List<ReadSaleDto> readSaleDto = _mapper.Map<List<ReadSaleDto>>(saleDatabase);
            return readSaleDto;
        }

        public ReadSaleDto GetSaleById(int id)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if (saleDatabase == null) return null;
            ReadSaleDto readSaleDto = _mapper.Map<ReadSaleDto>(saleDatabase);
            return readSaleDto;
        }

        public ReadSaleDto RegisterSale(CreateSaleDto createSaleDto)
        {
            Sale sale = _mapper.Map<Sale>(createSaleDto);
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return _mapper.Map<ReadSaleDto>(sale);
        }

        public Result UpdateSale(int id, UpdateSaleDto updateSaleDto)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if (saleDatabase == null) return Result.Fail("Sale not found");

            _context.Sales.Remove(saleDatabase);

            saleDatabase = _mapper.Map<Sale>(updateSaleDto);
            saleDatabase.Id = id;

            _context.Sales.Add(saleDatabase);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteSale(int id)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if (saleDatabase == null) return Result.Fail("Sale not found");

            _context.Sales.Remove(saleDatabase);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
