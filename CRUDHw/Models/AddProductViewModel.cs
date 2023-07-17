using System.ComponentModel.DataAnnotations;

namespace CRUDHw.Models
{
    public class AddProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The name cannot be empty.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The description cannot be empty.")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The count must be a positive number.")]
        public double Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The count must be a positive number.")]
        public int Quantity { get; set; }
        public string? Image { get; set; }
    }
}
