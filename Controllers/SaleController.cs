using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment_API.Data;
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
            return Ok(_context.Sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if(saleDatabase == null) return NotFound();
            return Ok(saleDatabase);
        }

        [HttpPost]
        public IActionResult RegisterSale([FromBody] Sale createSale)
        {
            Sale sale = new Sale()
            {
                IdSeller = createSale.IdSeller,
                StatusSale = createSale.StatusSale,
            };
            _context.Sales.Add(sale);
            _context.SaveChanges();

            List <Transaction> transactions = createSale.Transactions.ToList();
            foreach(Transaction transaction in transactions)
            {
                transaction.SaleId = sale.Id;
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }

            return CreatedAtAction(nameof(GetSaleById), new {Id = sale.Id}, sale);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] Sale updateSale)
        {
            Sale saleDatabase = _context.Sales.Where (saleQuery => saleQuery.Id == id).FirstOrDefault();
            if(saleDatabase ==null) return NotFound();

            List<Transaction> transactionsDataBase = _context.Transactions.Where(transactionQuery => transactionQuery.SaleId == id).ToList();
            foreach (Transaction transactionDatabase in transactionsDataBase)
            {
                _context.Transactions.Remove(transactionDatabase);
            }

            List<Transaction> transactions = updateSale.Transactions.ToList();
            foreach (Transaction transaction in transactions)
            {
                transaction.SaleId = saleDatabase.Id;
                _context.Transactions.Add(transaction);
            }

            saleDatabase.IdSeller = updateSale.IdSeller;
            saleDatabase.StatusSale = updateSale.StatusSale;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            Sale saleDatabase = _context.Sales.Where(saleQuery => saleQuery.Id == id).FirstOrDefault();
            if (saleDatabase == null) return NotFound();

            List<Transaction> transactionsDataBase = _context.Transactions.Where(transactionQuery => transactionQuery.SaleId == id).ToList();
            foreach (Transaction transactionDatabase in transactionsDataBase)
            {
                _context.Transactions.Remove(transactionDatabase);
            }

            _context.Sales.Remove(saleDatabase);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
