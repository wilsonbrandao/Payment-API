using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Data.DTOs.SaleDto;
using Payment_API.Models;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SaleController : ControllerBase
    {
        private readonly PaymentApiContext _context;
        private readonly IMapper _mapper;

        public SaleController(PaymentApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            List<Sale> saleDatabase = _context.Sales.ToList();
            List<ReadSaleDto> readSaleDto = _mapper.Map<List<ReadSaleDto>>(saleDatabase);
            return Ok(readSaleDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if(saleDatabase == null) return NotFound();
            ReadSaleDto readSaleDto = _mapper.Map<ReadSaleDto>(saleDatabase);
            return Ok(readSaleDto);
        }

        [HttpPost]
        public IActionResult RegisterSale([FromBody] CreateSaleDto createSaleDto)
        {
            Sale sale = _mapper.Map<Sale>(createSaleDto);
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSaleById), new {Id = sale.Id}, sale);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] UpdateSaleDto updateSaleDto)
        {
            Sale saleDatabase = _context.Sales.Where (saleQuery => saleQuery.Id == id).FirstOrDefault();
            if(saleDatabase ==null) return NotFound();

            _context.Sales.Remove(saleDatabase);

            saleDatabase = _mapper.Map<Sale>(updateSaleDto);
            saleDatabase.Id = id;

            _context.Sales.Add(saleDatabase);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if (saleDatabase == null) return NotFound();

            _context.Sales.Remove(saleDatabase);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
