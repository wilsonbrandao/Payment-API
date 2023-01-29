using System.ComponentModel.DataAnnotations;

namespace Payment_API.Data.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int ProductAmount { get; set; }
    }
}
