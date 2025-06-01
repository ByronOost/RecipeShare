using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5"),
                column: "ImageUrl",
                value: "/media/images/quinoa-salad-db7e1196-1ede-4dcc-b205-22b167c7e11e/");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654"),
                column: "ImageUrl",
                value: "/media/images/vegan-tacos-3eefd93e-22dc-48d6-9b01-e3e218ceed57/");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("c78fd9aa-3b6f-4663-bb79-fd408f2c3b45"),
                column: "ImageUrl",
                value: "/media/images/chicken-curry-d676031d-11cb-4ae4-9d2f-84287ee02815/");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: new Guid("f2c1a3b5-6df7-4e9b-8c0d-59f62b6c3a92"),
                column: "ImageUrl",
                value: "/media/images/spaghetti-bolognese-375358dd-713c-4463-a300-73082ad51b2d/");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
