using System;
using System.Collections.Generic;
using PoC.Entities;

namespace PoC.Repositories
{
    public interface IIngredientRepository
    {
        Ingredient GetIngredient(Guid id);
        IEnumerable<Ingredient> GetIngredients();

        void CreateIngredient(Ingredient ingredient);

        void UpdateIngredient(Ingredient ingredient);

        void DeleteIngredient(Guid id);

    }
}