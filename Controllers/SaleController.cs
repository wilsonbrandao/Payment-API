using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Data.DTOs.SaleDto;
using Payment_API.Models;
using Payment_API.Services;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            List<ReadSaleDto> readSaleDto = _saleService.GetSales();
            return Ok(readSaleDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            ReadSaleDto readSaleDto = _saleService.GetSaleById(id);
            if (readSaleDto == null) return null;
            return Ok(readSaleDto);
        }

        [HttpPost]
        public IActionResult RegisterSale([FromBody] CreateSaleDto createSaleDto)
        {
            ReadSaleDto readSaleDto = _saleService.RegisterSale(createSaleDto);
            return CreatedAtAction(nameof(GetSaleById), new {Id = readSaleDto.Id}, readSaleDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] UpdateSaleDto updateSaleDto)
        {
            Result result = _saleService.UpdateSale(id, updateSaleDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            Result result = _saleService.DeleteSale(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
