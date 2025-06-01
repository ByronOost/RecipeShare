using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietaryTags_Recipes_RecipeID",
                table: "DietaryTags");

            migrationBuilder.DropIndex(
                name: "IX_DietaryTags_RecipeID",
                table: "DietaryTags");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "DietaryTags");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DietaryTagRecipe",
                columns: table => new
                {
                    DietaryTagsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTagRecipe", x => new { x.DietaryTagsID, x.RecipesID });
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_DietaryTags_DietaryTagsID",
                        column: x => x.DietaryTagsID,
                        principalTable: "DietaryTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_Recipes_RecipesID",
                        column: x => x.RecipesID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("c78fd9aa-3b6f-4663-bb79-fd408f2c3b45"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("f2c1a3b5-6df7-4e9b-8c0d-59f62b6c3a92"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTagRecipe_RecipesID",
                table: "DietaryTagRecipe",
                column: "RecipesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietaryTagRecipe");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeID",
                table: "DietaryTags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DietaryTags",
                keyColumn: "ID",
                keyValue: new Guid("91c456af-ef6f-4904-8f53-4fdd486e4b49"),
                column: "RecipeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietaryTags",
                keyColumn: "ID",
                keyValue: new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"),
                column: "RecipeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietaryTags",
                keyColumn: "ID",
                keyValue: new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"),
                column: "RecipeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietaryTags",
                keyColumn: "ID",
                keyValue: new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"),
                column: "RecipeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietaryTags",
                keyColumn: "ID",
                keyValue: new Guid("e3a7c45f-90c3-4299-b202-f56bcf4e2c1f"),
                column: "RecipeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DietaryTags",
                keyColumn: "ID",
                keyValue: new Guid("eb540db0-23ab-4565-aef3-121fedd394d4"),
                column: "RecipeID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTags_RecipeID",
                table: "DietaryTags",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_DietaryTags_Recipes_RecipeID",
                table: "DietaryTags",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID");
        }
    }
}
