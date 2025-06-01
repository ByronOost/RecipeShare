using ClassLibrary.Constants;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data.DbConfigurations
{
    public static class RecipeSeedConfiguration
    {
        public static void RecipeSeed(this ModelBuilder builder)
        {
            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    ID = Guid.Parse(ContentIDs.SpaghettiBolognese),
                    Title = "Spaghetti Bolognese",
                    Ingredients = "Spaghetti, Ground beef, Onion, Garlic, Tomatoes, Olive oil, Basil, Salt, Pepper",
                    Steps = "1. Boil spaghetti until al dente.\n2. Sauté onions and garlic in olive oil.\n3. Add ground beef and cook until browned.\n4. Stir in tomatoes and seasonings. Simmer 15 minutes.\n5. Combine with spaghetti and serve.",
                    CookingTime = 30,
                    ImageUrl = "/media/images/spaghetti-bolognese-375358dd-713c-4463-a300-73082ad51b2d/54eafa36-6d67-4e1c-82ef-1351871c1cfe.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new Recipe
                {
                    ID = Guid.Parse(ContentIDs.QuinoaSalad),
                    Title = "Quinoa Salad",
                    Ingredients = "Quinoa, Cucumber, Tomato, Red onion, Lemon juice, Olive oil, Salt, Pepper, Parsley",
                    Steps = "1. Cook quinoa and let cool.\n2. Chop vegetables.\n3. Mix all ingredients in a bowl.\n4. Drizzle with lemon juice and olive oil.\n5. Season and toss to combine.",
                    CookingTime = 20,
                    ImageUrl = "/media/images/quinoa-salad-db7e1196-1ede-4dcc-b205-22b167c7e11e/b870fc65-4f33-462b-a68a-6806f360f66d.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new Recipe
                {
                    ID = Guid.Parse(ContentIDs.ChickenCurry),
                    Title = "Chicken Curry",
                    Ingredients = "Chicken breast, Onion, Garlic, Ginger, Tomatoes, Coconut milk, Curry powder, Cumin, Salt, Pepper",
                    Steps = "1. Sauté onions, garlic, and ginger.\n2. Add chicken and cook until golden.\n3. Stir in curry powder and tomatoes.\n4. Add coconut milk and simmer for 20 minutes.\n5. Serve with rice.",
                    CookingTime = 35,
                    ImageUrl = "/media/images/chicken-curry-d676031d-11cb-4ae4-9d2f-84287ee02815/f81f2249-6ccc-434e-93e0-dfaad53158a5.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                },
                new Recipe
                {
                    ID = Guid.Parse(ContentIDs.VeganTacos),
                    Title = "Vegan Tacos",
                    Ingredients = "Taco shells, Black beans, Corn, Avocado, Tomato, Lettuce, Lime juice, Cumin, Chili powder",
                    Steps = "1. Heat beans with cumin and chili powder.\n2. Prepare vegetables and toppings.\n3. Warm taco shells.\n4. Assemble tacos with beans and toppings.\n5. Drizzle with lime juice and serve.",
                    CookingTime = 25,
                    ImageUrl = "/media/images/vegan-tacos-3eefd93e-22dc-48d6-9b01-e3e218ceed57/91afedcf-2720-4aba-9e59-bb99a2073f22.jpg",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Parse("2025-01-01"),
                    ModifiedDate = null
                }
            );
        }
    }
}
