using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PoC;
using PoC.Dtos;
using PoC.Entities;
using PoC.Repositories;

namespace Poc.Controllers
{
    [ApiController]
    [Route("ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepository repository;

        public IngredientsController(IIngredientRepository repository)
        {
            this.repository = repository;
        }

        // GET /ingredients
        [HttpGet]
        public IEnumerable<IngredientDto> GetIngredients()
        {
            var ingredients = repository.GetIngredients().Select(ingredients => ingredients.AsDto());
            return ingredients;
        }

        // GET /ingredinets/{id}
        [HttpGet("{id}")]
        public ActionResult<IngredientDto> GetIngredient(Guid id)
        {
            var ingredient = repository.GetIngredient(id);

            if (ingredient is null)
            {
                return NotFound();
            }
            return ingredient.AsDto();
        }

        // POST /ingredients
        [HttpPost]
        public ActionResult<IngredientDto> CreateIngredient(CreateIngredientDto ingredientDto)
        {
            Ingredient ingredient = new()
            {
                Id = Guid.NewGuid(),
                Name = ingredientDto.Name,
                Quantity = ingredientDto.Quantity,
                Category = ingredientDto.Category
            };

            repository.CreateIngredient(ingredient);

            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient.AsDto());
        }

        // PUT /ingredients
        [HttpPut("{id}")]
        public ActionResult UpdateIngredient(Guid id, UpdateIngredientDto ingredientDto)
        {
            var existingIngredient = repository.GetIngredient(id);
            if (existingIngredient is null)
            {
                return NotFound();
            }

            Ingredient updatedIngredient = existingIngredient with
            {
                Name = ingredientDto.Name,
                Quantity = ingredientDto.Quantity,
                Category = ingredientDto.Category
            };

            repository.UpdateIngredient(updatedIngredient);

            return NoContent();
        }

        // DELETE /ingredients
        [HttpDelete("{id}")]
        public ActionResult DeleteIngredient(Guid id)
        {
            var existingIngredient = repository.GetIngredient(id);
            if (existingIngredient is null)
            {
                return NotFound();
            }

            repository.DeleteIngredient(id);
            return NoContent();
        }

    }
}