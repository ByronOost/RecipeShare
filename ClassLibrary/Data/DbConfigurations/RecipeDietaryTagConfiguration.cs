using ClassLibrary.Constants;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data.DbConfigurations
{
    public static class RecipeDietaryTagConfiguration
    {
        public static void RecipeDietaryTagSeed(this ModelBuilder builder)
        {
            builder.Entity<RecipeDietaryTag>().HasData(
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin1),
                    RecipeID = Guid.Parse(ContentIDs.SpaghettiBolognese),
                    DietaryTagID = Guid.Parse(ContentIDs.GlutenFree)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin2),
                    RecipeID = Guid.Parse(ContentIDs.QuinoaSalad),
                    DietaryTagID = Guid.Parse(ContentIDs.Vegan)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin3),
                    RecipeID = Guid.Parse(ContentIDs.QuinoaSalad),
                    DietaryTagID = Guid.Parse(ContentIDs.GlutenFree)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin4),
                    RecipeID = Guid.Parse(ContentIDs.QuinoaSalad),
                    DietaryTagID = Guid.Parse(ContentIDs.DairyFree)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin5),
                    RecipeID = Guid.Parse(ContentIDs.ChickenCurry),
                    DietaryTagID = Guid.Parse(ContentIDs.DairyFree)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin6),
                    RecipeID = Guid.Parse(ContentIDs.VeganTacos),
                    DietaryTagID = Guid.Parse(ContentIDs.Vegan)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin7),
                    RecipeID = Guid.Parse(ContentIDs.VeganTacos),
                    DietaryTagID = Guid.Parse(ContentIDs.DairyFree)
                },
                new RecipeDietaryTag
                {
                    ID = Guid.Parse(ContentIDs.RecipeDietaryTagJoin8),
                    RecipeID = Guid.Parse(ContentIDs.VeganTacos),
                    DietaryTagID = Guid.Parse(ContentIDs.GlutenFree)
                }
            );
        }
    }
}
