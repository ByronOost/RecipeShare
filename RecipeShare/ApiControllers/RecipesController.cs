using ClassLibrary.DTOs;
using ClassLibrary.Helpers;
using ClassLibrary.Repositories.Interfaces;
using ClassLibrary.Utilities;
using FuzzySharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeShare.Helpers;

namespace RecipeShare.ApiControllers
{
    [Area("API")]
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository; 

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeRepository.GetAsQueryable().ToListAsync();

            return ApiResponseHelper.OkResponse("Fetched recipes", recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var recipe = await _recipeRepository.GetById(id);

            if (recipe == null)
            {
                return ApiResponseHelper.NotFoundResponse("Recipe not found");
            }

            return ApiResponseHelper.OkResponse("Recipe found", recipe);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        public async Task<IActionResult> Create([FromBody] RecipeDto dto)
        {
            var recipe = RecipeMapperHelper.ToEntity(dto);

            recipe.ID = Guid.NewGuid();

            await _recipeRepository.Create(recipe);
            return ApiResponseHelper.CreatedResponse("Recipe created", recipe.ToDto());
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        public async Task<IActionResult> Update([FromBody] RecipeDto dto)
        {
            if (dto.ID == Guid.Empty)
            {
                return ApiResponseHelper.BadRequestResponse("ID cannot be null");
            }

            var existing = await _recipeRepository.GetById((Guid)dto.ID!);
            if (existing == null)
            {
                return ApiResponseHelper.NotFoundResponse("Recipe not found");
            }
            var oldImage = existing.ImageUrl;

            if (dto.ImageUrl == null)
            {
                dto.ImageUrl = oldImage;
            }

            var updated = RecipeMapperHelper.ToEntity(dto, existing);

            await _recipeRepository.Update(updated);

            return ApiResponseHelper.OkResponse("Recipe updated", updated.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeRepository.Delete(id);

            return ApiResponseHelper.OkResponse("Recipe deleted");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? term, [FromQuery] string? dietaryTag)
        {
            var recipes = _recipeRepository.GetAsQueryable();

            var filteredQuery = recipes.ApplyFilters(term, dietaryTag);

            var resultList = await filteredQuery
                .OrderBy(x => x.Title)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(term))
            {
                string lowerTerm = term.ToLower();

                resultList = resultList
                    .Where(v =>
                        Fuzz.PartialRatio(v.Title.ToLower(), lowerTerm) > 85 ||
                        Fuzz.PartialRatio(v.Ingredients.ToLower(), lowerTerm) > 95 ||
                        Fuzz.PartialRatio(v.Steps.ToLower(), lowerTerm) > 95||
                        Fuzz.PartialRatio(v.CookingTime.ToString().ToLower(), lowerTerm) > 95
                    )
                    .ToList();
            }

            return ApiResponseHelper.OkResponse("Search results", resultList);
        }

        [HttpDelete("{recipeId}/dietarytags")]
        public async Task<IActionResult> RemoveAllDietaryTags(Guid recipeId)
        {
            var result = await _recipeRepository.RemoveAllDietaryTags(recipeId);

            if (!result.Success)
            {
                return ApiResponseHelper.BadRequestResponse(result.Message);
            }

            return NoContent();
        }
    }
}
