using System;

namespace PoC.Entities
{
    public record Ingredient
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Quantity { get; init; }
        public string Category { get; init; }
    }
}