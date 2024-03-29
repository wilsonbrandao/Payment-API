﻿using Payment_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment_API.Models
{
    public class Sale
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "pending seller field")]
        public int IdSeller { get; set; }
        public virtual Seller Seller { get; set; }
        public EStatusSale StatusSale { get; set; } = EStatusSale.AwaitingPayment;
        public DateTime DateSale { get; set; } = DateTime.Now;

        //ef relationship between product and sale
        public virtual List<Transaction> Transactions { get; set; }
    }
}
