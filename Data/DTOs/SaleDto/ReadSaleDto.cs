using Payment_API.Enums;
using Payment_API.Models;

using System.ComponentModel.DataAnnotations;

namespace Payment_API.Data.DTOs.SaleDto
{
    public class ReadSaleDto
    {
        public int Id { get; set; }
        public virtual Seller Seller { get; set; }
        public EStatusSale StatusSale { get; set; }
        public DateTime DateSale { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
