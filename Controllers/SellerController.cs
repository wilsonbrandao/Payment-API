using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
using Payment_API.Data.DTOs.SellerDto;
using Payment_API.Models;
using Payment_API.Services;

namespace Payment_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SellerController : ControllerBase
    {
        private readonly SellerService _sellerService;   

        public SellerController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public IActionResult GetSellers ()
        {
            List<ReadSellerDto> readSellerDto = _sellerService.GetSellers();
            return Ok(readSellerDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSellerById (int id)
        {
            ReadSellerDto readSellerDto = _sellerService.GetSellerById(id);
            if(readSellerDto == null) return NotFound();

            return Ok(readSellerDto);
        }

        [HttpPost]
        public IActionResult RegisterSeller([FromBody] CreateSellerDto createSellerDto)
        {
            ReadSellerDto readSellerDto = _sellerService.RegisterSeller(createSellerDto);
            return CreatedAtAction(nameof(GetSellerById), new {Id = readSellerDto.Id}, readSellerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeller(int id, [FromBody] UpdateSellerDto updateSellerDto)
        {
            Result result = _sellerService.UpdateSeller(id, updateSellerDto);
            if (result.IsFailed) return NotFound();          

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeller(int id)
        {
            Result result = _sellerService.DeleteSeller(id);
            if(result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
