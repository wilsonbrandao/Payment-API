using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Data.DTOs.Seller;
using Payment_API.Models;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SellerController : ControllerBase
    {
        private readonly PaymentApiContext _context;
        private readonly IMapper _mapper;

        public SellerController(PaymentApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSellers ()
        {
            List<Seller> sellers = _context.Sellers.ToList();
            List<ReadSellerDto> ListReadSellerDto = _mapper.Map<List<ReadSellerDto>>(sellers);
            return Ok(ListReadSellerDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSellerById (int id)
        {
            Seller seller = _context.Sellers.Where(seller => seller.Id == id).FirstOrDefault();
            if(seller == null) return NotFound();
            ReadSellerDto readSellerDto = _mapper.Map<ReadSellerDto>(seller);
            return Ok(readSellerDto);
        }

        [HttpPost]
        public IActionResult RegisterSeller([FromBody] CreateSellerDto createSellerDto)
        {
            Seller seller = _mapper.Map<Seller>(createSellerDto);

            _context.Sellers.Add(seller);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSellerById), new {Id = seller.Id}, seller);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeller(int id, [FromBody] UpdateSellerDto updateSellerDto)
        {
            Seller sellerDatabase = _context.Sellers.Where(sellerQuery => sellerQuery.Id == id).FirstOrDefault();  
            if (sellerDatabase == null) return NotFound();

            sellerDatabase = _mapper.Map(updateSellerDto, sellerDatabase);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeller(int id)
        {
            Seller seller = _context.Sellers.Where(seller => seller.Id == id).FirstOrDefault();
            
            _context.Sellers.Remove(seller);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
