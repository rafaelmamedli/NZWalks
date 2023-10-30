using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Difficulities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Difficulities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Difficulities",
                keyColumn: "Id",
                keyValue: new Guid("5055e124-4c80-4b55-8832-222fc2c3598d"),
                column: "MyProperty",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Difficulities",
                keyColumn: "Id",
                keyValue: new Guid("6ca6a6d9-7bc9-428c-88f0-b50a6bd1a2da"),
                column: "MyProperty",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Difficulities",
                keyColumn: "Id",
                keyValue: new Guid("b1b4d2ed-6392-4324-a8bd-6afb90608b47"),
                column: "MyProperty",
                value: 0);
        }
    }
}
