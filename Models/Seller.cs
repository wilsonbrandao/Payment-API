using System.ComponentModel.DataAnnotations;

namespace Payment_API.Models
{
    public class Seller
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="CPF field is required")]
        [StringLength(11, ErrorMessage = "CPF field cannot exceed 11 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CPF must be numeric")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "NAME field is required")]
        [StringLength(100, ErrorMessage = "The name field cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "EMAIL field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PHONENUMBER field is required")]
        public string PhoneNumber { get; set; }
    }
}
