using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DietaryTags",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DietaryTags_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RecipeDietaryTag",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DietaryTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDietaryTag", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeDietaryTag_DietaryTags_DietaryTagId",
                        column: x => x.DietaryTagId,
                        principalTable: "DietaryTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDietaryTag_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DietaryTags",
                columns: new[] { "ID", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "RecipeID" },
                values: new object[,]
                {
                    { new Guid("91c456af-ef6f-4904-8f53-4fdd486e4b49"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Paleo", null },
                    { new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Gluten Free", null },
                    { new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Vegan", null },
                    { new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Dairy Free", null },
                    { new Guid("e3a7c45f-90c3-4299-b202-f56bcf4e2c1f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Keto", null },
                    { new Guid("eb540db0-23ab-4565-aef3-121fedd394d4"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, "Vegetarian", null }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "ID", "CookingTime", "CreatedDate", "Ingredients", "IsActive", "IsDeleted", "ModifiedDate", "Steps", "Title" },
                values: new object[,]
                {
                    { new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5"), 20, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quinoa, Cucumber, Tomato, Red onion, Lemon juice, Olive oil, Salt, Pepper, Parsley", true, false, null, "1. Cook quinoa and let cool.\n2. Chop vegetables.\n3. Mix all ingredients in a bowl.\n4. Drizzle with lemon juice and olive oil.\n5. Season and toss to combine.", "Quinoa Salad" },
                    { new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654"), 25, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taco shells, Black beans, Corn, Avocado, Tomato, Lettuce, Lime juice, Cumin, Chili powder", true, false, null, "1. Heat beans with cumin and chili powder.\n2. Prepare vegetables and toppings.\n3. Warm taco shells.\n4. Assemble tacos with beans and toppings.\n5. Drizzle with lime juice and serve.", "Vegan Tacos" },
                    { new Guid("c78fd9aa-3b6f-4663-bb79-fd408f2c3b45"), 35, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicken breast, Onion, Garlic, Ginger, Tomatoes, Coconut milk, Curry powder, Cumin, Salt, Pepper", true, false, null, "1. Sauté onions, garlic, and ginger.\n2. Add chicken and cook until golden.\n3. Stir in curry powder and tomatoes.\n4. Add coconut milk and simmer for 20 minutes.\n5. Serve with rice.", "Chicken Curry" },
                    { new Guid("f2c1a3b5-6df7-4e9b-8c0d-59f62b6c3a92"), 30, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spaghetti, Ground beef, Onion, Garlic, Tomatoes, Olive oil, Basil, Salt, Pepper", true, false, null, "1. Boil spaghetti until al dente.\n2. Sauté onions and garlic in olive oil.\n3. Add ground beef and cook until browned.\n4. Stir in tomatoes and seasonings. Simmer 15 minutes.\n5. Combine with spaghetti and serve.", "Spaghetti Bolognese" }
                });

            migrationBuilder.InsertData(
                table: "RecipeDietaryTag",
                columns: new[] { "ID", "DietaryTagId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654"), new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"), new Guid("f2c1a3b5-6df7-4e9b-8c0d-59f62b6c3a92") },
                    { new Guid("2c7e1d68-3f55-4e45-9d29-04b71de82cf2"), new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"), new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5") },
                    { new Guid("3f1a4ae9-d843-4cb2-9373-8f9e1df2ecb9"), new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"), new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5") },
                    { new Guid("45c5e3cc-6c6c-47f3-9a36-c4a9fca2ee3e"), new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"), new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5") },
                    { new Guid("51d94b7a-9e30-4126-8ff1-06658cfdcb84"), new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"), new Guid("c78fd9aa-3b6f-4663-bb79-fd408f2c3b45") },
                    { new Guid("6aeb3d24-b64d-4192-a7d2-24a3c8c25e3d"), new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"), new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654") },
                    { new Guid("72e453b5-c70a-4a3e-8799-24e914deec77"), new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"), new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654") },
                    { new Guid("83b61f61-f0f0-4b3a-9ae6-36f771d3ce6e"), new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"), new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTags_RecipeID",
                table: "DietaryTags",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDietaryTag_DietaryTagId",
                table: "RecipeDietaryTag",
                column: "DietaryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDietaryTag_RecipeId",
                table: "RecipeDietaryTag",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeDietaryTag");

            migrationBuilder.DropTable(
                name: "DietaryTags");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
