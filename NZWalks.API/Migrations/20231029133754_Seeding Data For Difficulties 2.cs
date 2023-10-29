using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficulties2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulities",
                columns: new[] { "Id", "MyProperty", "Name" },
                values: new object[,]
                {
                    { new Guid("5055e124-4c80-4b55-8832-222fc2c3598d"), 0, "Medium" },
                    { new Guid("6ca6a6d9-7bc9-428c-88f0-b50a6bd1a2da"), 0, "Easy" },
                    { new Guid("b1b4d2ed-6392-4324-a8bd-6afb90608b47"), 0, "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("07845a01-4bd5-401c-b682-8accf5febae9"), "AKL", "Southland", "Image-Url" },
                    { new Guid("fee94f55-b115-40fd-a044-b2d1efb41d5b"), "AKL", "Auckland", "Image-Url" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulities",
                keyColumn: "Id",
                keyValue: new Guid("5055e124-4c80-4b55-8832-222fc2c3598d"));

            migrationBuilder.DeleteData(
                table: "Difficulities",
                keyColumn: "Id",
                keyValue: new Guid("6ca6a6d9-7bc9-428c-88f0-b50a6bd1a2da"));

            migrationBuilder.DeleteData(
                table: "Difficulities",
                keyColumn: "Id",
                keyValue: new Guid("b1b4d2ed-6392-4324-a8bd-6afb90608b47"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("07845a01-4bd5-401c-b682-8accf5febae9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fee94f55-b115-40fd-a044-b2d1efb41d5b"));
        }
    }
}
