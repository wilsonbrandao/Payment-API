﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment_API.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int SaleId { get; set; }
        public int ProductId { get; set; }

        public DateTime DateTimeTransaction { get; set; } = DateTime.Now;

        //virtual to lazy load
        [JsonIgnore]
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
