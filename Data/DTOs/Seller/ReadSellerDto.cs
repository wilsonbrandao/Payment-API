using Payment_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment_API.Data.DTOs.Seller
{
    public class ReadSellerDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
