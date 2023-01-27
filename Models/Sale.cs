using Payment_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Payment_API.Models
{
    public class Sale
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "pending seller field")]
        public int IdSeller { get; set; }
        public Seller Seller { get; set; }

        public EStatusSale StatusSale { get; set; } = EStatusSale.AwaitingPayment;
        
        public DateTime DateSale { get; set; } = DateTime.Now;
        
        //ef relation between product and sale
        public virtual List<Transaction> Transactions { get; set; }
    }
}
