using Payment_API.Enums;
using Payment_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Payment_API.Data.DTOs.SaleDto
{
    public class UpdateSaleDto
    {
        [Required(ErrorMessage = "pending seller field")]
        public int IdSeller { get; set; }
        [Required(ErrorMessage = "pending StatusSale field")]
        public EStatusSale StatusSale { get; set; } 
        public DateTime DateSale { get; set; } = DateTime.Now;
        [MinLength(1, ErrorMessage = "The sale must have at least 1 product")]
        public List<Transaction> Transactions { get; set; }
    }
}
