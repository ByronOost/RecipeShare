using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietaryTag_DietaryTags_DietaryTagId",
                table: "RecipeDietaryTag");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietaryTag_Recipes_RecipeId",
                table: "RecipeDietaryTag");

            migrationBuilder.DropTable(
                name: "DietaryTagRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDietaryTag",
                table: "RecipeDietaryTag");

            migrationBuilder.RenameTable(
                name: "RecipeDietaryTag",
                newName: "RecipeDietaryTags");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "RecipeDietaryTags",
                newName: "RecipeID");

            migrationBuilder.RenameColumn(
                name: "DietaryTagId",
                table: "RecipeDietaryTags",
                newName: "DietaryTagID");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDietaryTag_RecipeId",
                table: "RecipeDietaryTags",
                newName: "IX_RecipeDietaryTags_RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDietaryTag_DietaryTagId",
                table: "RecipeDietaryTags",
                newName: "IX_RecipeDietaryTags_DietaryTagID");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeID",
                table: "DietaryTags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDietaryTags",
                table: "RecipeDietaryTags",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietaryTags_DietaryTags_DietaryTagID",
                table: "RecipeDietaryTags",
                column: "DietaryTagID",
                principalTable: "DietaryTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietaryTags_Recipes_RecipeID",
                table: "RecipeDietaryTags",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietaryTags_Recipes_RecipeID",
                table: "DietaryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietaryTags_DietaryTags_DietaryTagID",
                table: "RecipeDietaryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietaryTags_Recipes_RecipeID",
                table: "RecipeDietaryTags");

            migrationBuilder.DropIndex(
                name: "IX_DietaryTags_RecipeID",
                table: "DietaryTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDietaryTags",
                table: "RecipeDietaryTags");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "DietaryTags");

            migrationBuilder.RenameTable(
                name: "RecipeDietaryTags",
                newName: "RecipeDietaryTag");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "RecipeDietaryTag",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "DietaryTagID",
                table: "RecipeDietaryTag",
                newName: "DietaryTagId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDietaryTags_RecipeID",
                table: "RecipeDietaryTag",
                newName: "IX_RecipeDietaryTag_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDietaryTags_DietaryTagID",
                table: "RecipeDietaryTag",
                newName: "IX_RecipeDietaryTag_DietaryTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDietaryTag",
                table: "RecipeDietaryTag",
                column: "ID");

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

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTagRecipe_RecipesID",
                table: "DietaryTagRecipe",
                column: "RecipesID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietaryTag_DietaryTags_DietaryTagId",
                table: "RecipeDietaryTag",
                column: "DietaryTagId",
                principalTable: "DietaryTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietaryTag_Recipes_RecipeId",
                table: "RecipeDietaryTag",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
