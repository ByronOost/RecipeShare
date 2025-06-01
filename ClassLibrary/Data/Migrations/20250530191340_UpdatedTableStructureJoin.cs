using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTableStructureJoin : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
