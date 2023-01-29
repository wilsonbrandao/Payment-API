using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;

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
            return Ok(_context.Sales);
        }
    }
}
