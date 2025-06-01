using ClassLibrary.Constants;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data.DbConfigurations
{
    public static class DietaryTagSeedConfiguration
    {
        public static void DietaryTagSeed(this ModelBuilder builder)
        {
            builder.Entity<DietaryTag>().HasData(
                new DietaryTag
                {
                    ID = Guid.Parse(ContentIDs.Vegan),
                    Name = "Vegan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new DietaryTag
                {
                    ID = Guid.Parse(ContentIDs.Vegetarian),
                    Name = "Vegetarian",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new DietaryTag
                {
                    ID = Guid.Parse(ContentIDs.GlutenFree),
                    Name = "Gluten Free",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new DietaryTag
                {
                    ID = Guid.Parse(ContentIDs.DairyFree),
                    Name = "Dairy Free",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new DietaryTag
                {
                    ID = Guid.Parse(ContentIDs.Keto),
                    Name = "Keto",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new DietaryTag
                {
                    ID = Guid.Parse(ContentIDs.Paleo),
                    Name = "Paleo",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                }
            );
        }
    }
}
