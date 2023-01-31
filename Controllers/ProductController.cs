using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Data.DTOs.ProductDto;
using Payment_API.Models;
using Payment_API.Services;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<ReadProductDto> readProductDto = _productService.GetProducts();
            return Ok(readProductDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            ReadProductDto readProductDto = _productService.GetProductById(id);
            if(readProductDto == null) return NotFound();

            return Ok(readProductDto);
        }

        [HttpPost()]
        public IActionResult RegisterProduct([FromBody] CreateProductDto createProductDto)
        {
            ReadProductDto readProductDto = _productService.RegisterProduct(createProductDto);
            return CreatedAtAction(nameof(GetProductById), new {Id = readProductDto.Id }, readProductDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            Result result = _productService.UpdateProduct(id, updateProductDto);
            if (result.IsFailed) return NotFound();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Result result = _productService.DeleteProduct(id);
            if (result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
