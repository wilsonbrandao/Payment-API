using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Models;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly PaymentApiContext _context;

        public ProductController(PaymentApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();
            if(productDatabase == null) return NotFound();
            return Ok(productDatabase);
        }

        [HttpPost()]
        public IActionResult RegisterProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();

            productDatabase.Name = product.Name;
            productDatabase.ProductAmount = product.ProductAmount;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();

            _context.Products.Remove(productDatabase);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
