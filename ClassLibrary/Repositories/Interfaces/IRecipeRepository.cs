using ClassLibrary.Models;
using ClassLibrary.Operations;

namespace ClassLibrary.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> GetAsQueryable();
        Task<Recipe?> GetById(Guid id);
        Task<OperationResult> Create(Recipe recipe);
        Task<OperationResult> Update(Recipe recipe);
        Task<OperationResult> Delete(Guid id);
        Task<OperationResult> RemoveAllDietaryTags(Guid recipeId);
    }
}
