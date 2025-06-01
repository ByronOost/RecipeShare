using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Helpers
{
    public static class RecipeMapperHelper
    {
        public static RecipeDto ToDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                ID = recipe.ID,
                Title = recipe.Title,
                Ingredients = recipe.Ingredients,
                Steps = recipe.Steps,
                CookingTime = recipe.CookingTime,
                ImageUrl = recipe.ImageUrl,
                DietaryTags = recipe.RecipeDietaryTags.Select(t => t.DietaryTagID).ToList()
            };
        }

        public static Recipe ToEntity(this RecipeDto dto, Recipe? existingRecipe = null)
        {
            var recipe = existingRecipe ?? new Recipe();

            recipe.Title = dto.Title;
            recipe.Ingredients = dto.Ingredients;
            recipe.Steps = dto.Steps;
            recipe.CookingTime = dto.CookingTime;
            recipe.ImageUrl = dto.ImageUrl;

            recipe.RecipeDietaryTags = dto.DietaryTags
                .Select(id => new RecipeDietaryTag { DietaryTagID = id })
                .ToList();

            return recipe;
        }
    }
}
