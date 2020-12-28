using System.ComponentModel.DataAnnotations;

namespace PoC.Dtos
{
    public class CreateIngredientDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter positive number.")]
        public decimal Quantity { get; init; }

        [Required]
        public string Category { get; init; }
    }
}