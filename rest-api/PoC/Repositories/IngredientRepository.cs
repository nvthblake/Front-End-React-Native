using System;
using System.Collections.Generic;
using System.Linq;
using PoC.Entities;

namespace PoC.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly List<Ingredient> ingredients = new()
        {
            new Ingredient { Id = Guid.NewGuid(), Name = "Steak", Quantity = 2, Category = "Meat" },
            new Ingredient { Id = Guid.NewGuid(), Name = "Tomato", Quantity = 5, Category = "Vegetable" },
            new Ingredient { Id = Guid.NewGuid(), Name = "Banana", Quantity = 8, Category = "Fruit" },
        };
        public Ingredient GetIngredient(Guid id)
        {
            return ingredients.Where(ingredient => ingredient.Id == id).SingleOrDefault();
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return ingredients;
        }
        public void CreateIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void DeleteIngredient(Guid id)
        {
            var index = ingredients.FindIndex(existingIngredient => existingIngredient.Id == id);
            ingredients.RemoveAt(index);
        }


        public void UpdateIngredient(Ingredient ingredient)
        {
            var index = ingredients.FindIndex(existingIngredient => existingIngredient.Id == ingredient.Id);
            ingredients[index] = ingredient;
        }
    }
}