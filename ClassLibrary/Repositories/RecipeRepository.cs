using ClassLibrary.Data;
using ClassLibrary.Models;
using ClassLibrary.Operations;
using ClassLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RecipeRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        private IQueryable<Recipe> Base()
        {
            return _dbContext.Set<Recipe>()
                .Include(r => r.RecipeDietaryTags)
                    .ThenInclude(rd => rd.DietaryTag)
                .AsNoTracking()
                .AsQueryable();
        }

        public IQueryable<Recipe> GetAsQueryable()
        {
            return Base();
        }

        public async Task<Recipe?> GetById(Guid id)
        {
            try
            {
                return await Base().FirstOrDefaultAsync(x => x.ID.Equals(id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<OperationResult> Create(Recipe recipe)
        {
            try
            {
                await _dbContext.Recipes.AddAsync(recipe);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessResult("Recipe created successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.FailureResult("Failed to create Recipe.", ex);
            }
        }

        public async Task<OperationResult> Update(Recipe recipe)
        {
            try
            {
                _dbContext.Recipes.Update(recipe);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessResult("Recipe updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.FailureResult("Failed to update Recipe.", ex);
            }
        }

        public async Task<OperationResult> Delete(Guid recipeId)
        {
            try
            {
                var recipe = await _dbContext.Recipes
                    .Include(r => r.RecipeDietaryTags)
                        .ThenInclude(rdt => rdt.DietaryTag)
                    .FirstOrDefaultAsync(r => r.ID == recipeId);

                if (recipe == null)
                    return OperationResult.FailureResult("Recipe not found.");

                _dbContext.Recipes.Remove(recipe);
                await _dbContext.SaveChangesAsync();

                return OperationResult.SuccessResult("Recipe deleted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.FailureResult("Failed to delete Recipe.", ex);
            }

        }
        public async Task<OperationResult> RemoveAllDietaryTags(Guid recipeId)
        {
            try
            {
                var recipe = await _dbContext.Recipes
                    .Include(r => r.RecipeDietaryTags)
                    .FirstOrDefaultAsync(r => r.ID == recipeId);

                if (recipe == null)
                {
                    return OperationResult.FailureResult("Recipe not found.");
                }

                _dbContext.RecipeDietaryTags.RemoveRange(recipe.RecipeDietaryTags);
                await _dbContext.SaveChangesAsync();

                return OperationResult.SuccessResult("All dietary tags removed successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.FailureResult("Failed to remove dietary tags.", ex);
            }
        }
    }
}
