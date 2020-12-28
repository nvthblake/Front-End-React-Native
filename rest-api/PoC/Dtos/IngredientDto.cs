using System;

namespace PoC.Dtos
{
    public record IngredientDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Quantity { get; init; }
        public string Category { get; init; }
    }
}