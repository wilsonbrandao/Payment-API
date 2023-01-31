using Payment_API.Enums;
using Payment_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Payment_API.Data.DTOs.SaleDto
{
    public class CreateSaleDto
    {
        [Required(ErrorMessage = "pending seller field")]
        public int IdSeller { get; set; }
        public EStatusSale StatusSale { get; set; } = EStatusSale.AwaitingPayment;
        public DateTime DateSale { get; set; } = DateTime.Now;
        [MinLength(1, ErrorMessage = "The sale must have at least 1 product")]
        public List<Transaction> Transactions { get; set; }
    }
}
