using System.ComponentModel.DataAnnotations;

namespace Payment_API.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int SaleId { get; set; }
        public int ProductId { get; set; }

        public DateTime DateTimeTransaction { get; set; }

        //virtual to lazy load
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }

    }
}
