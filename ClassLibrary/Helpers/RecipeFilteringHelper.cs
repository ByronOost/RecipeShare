using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helpers
{
    public static class RecipeFilteringHelper
    {
        public static IQueryable<Recipe> ApplyFilters(this IQueryable<Recipe> query, string? term, string? dietaryTagId)
        {
            Guid? dietaryTagGuid = null;

            if (dietaryTagId != null)
            {
                dietaryTagGuid = Guid.Parse(dietaryTagId);
            }

            if (!string.IsNullOrWhiteSpace(term))
            {
                var lowerTerm = term.ToLower();

                query = query.Where(r =>
                    r.Title.ToLower().Contains(lowerTerm) ||
                    r.Ingredients.ToLower().Contains(lowerTerm) ||
                    r.Steps.ToLower().Contains(lowerTerm) ||
                    r.CookingTime.ToString().ToLower().Contains(lowerTerm)
                );
            }

            if (dietaryTagGuid.HasValue)
            {
                query = query.Where(r =>
                    r.RecipeDietaryTags.Any(rdt => rdt.DietaryTagID == dietaryTagGuid.Value)
                );
            }

            return query;
        }
    }
}
