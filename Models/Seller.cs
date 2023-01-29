using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment_API.Models
{
    public class Seller
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="'Cpf' field is required")]
        [StringLength(11, ErrorMessage = "'Cpf' field cannot exceed 11 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "'Cpf' must be numeric")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "'Name' field is required")]
        [StringLength(100, ErrorMessage = "'Name' field cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'Email' field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'PhoneNumber' field is required")]
        public string PhoneNumber { get; set; }

        //EF relationship
        [JsonIgnore]
        public virtual List<Sale> Sales { get; set; }
    }
}
