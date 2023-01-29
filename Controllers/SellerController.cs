using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Models;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SellerController : ControllerBase
    {
        private readonly PaymentApiContext _context;

        public SellerController(PaymentApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSellers ()
        {
            return Ok(_context.Sellers);
        }

        [HttpGet("{id}")]
        public IActionResult GetSellerById (int id)
        {
            Seller seller = _context.Sellers.Where(seller => seller.Id == id).FirstOrDefault();
            if(seller == null) return NotFound();
            return Ok(seller);
        }

        [HttpPost]
        public IActionResult RegisterSeller([FromBody] Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSellerById), new {Id = seller.Id}, seller);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeller(int id, [FromBody] Seller seller)
        {
            Seller sellerDatabase = _context.Sellers.Where(sellerQuery => sellerQuery.Id == id).FirstOrDefault();  
            if (sellerDatabase == null) return NotFound();

            sellerDatabase.Cpf = seller.Cpf;
            sellerDatabase.Name = seller.Name;
            sellerDatabase.Email = seller.Email;
            sellerDatabase.PhoneNumber = seller.PhoneNumber;

            _context.Sellers.Update(sellerDatabase);
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
