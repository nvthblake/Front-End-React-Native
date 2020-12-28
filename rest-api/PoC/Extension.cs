using PoC.Dtos;
using PoC.Entities;

namespace PoC
{
    public static class Extensions
    {
        public static IngredientDto AsDto(this Ingredient ingredient)
        {
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                Category = ingredient.Category,
            };
        }
    }
}