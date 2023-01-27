using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment_API.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "'Name' field is required")]
        [StringLength(100, ErrorMessage = "'Name' field cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'ProductAmount' field is required")]
        public int ProductAmount { get; set; }

        //ef relation between product and sale
        [JsonIgnore]
        public virtual Transaction Transactions { get; set; }
    }
}
