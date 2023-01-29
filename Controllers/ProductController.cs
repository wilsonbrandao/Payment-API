using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Data.DTOs.Product;
using Payment_API.Models;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly PaymentApiContext _context;
        private readonly IMapper _mapper;

        public ProductController(PaymentApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            List<ReadProductDto> readProductDto = _mapper.Map<List<ReadProductDto>>(products);
            return Ok(readProductDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();
            if(productDatabase == null) return NotFound();

            ReadProductDto readProdutoDto = _mapper.Map<ReadProductDto>(productDatabase);

            return Ok(readProdutoDto);
        }

        [HttpPost()]
        public IActionResult RegisterProduct([FromBody] CreateProductDto createProductDto)
        {
            Product product = _mapper.Map<Product>(createProductDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductById), new {Id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();

            _mapper.Map(updateProductDto, productDatabase);

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
