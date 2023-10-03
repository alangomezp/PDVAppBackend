using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessLogic.BusinessLogic.Persistence
{
    /// <inheritdoc />
    public partial class PreloadingFundAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FundAccounts",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "LastUpdatedDate", "Owner" },
                values: new object[,]
                {
                    { new Guid("21095b0c-44aa-42b6-aa7d-657325868606"), new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5338), "Efectivo", false, new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5339), "Omayra" },
                    { new Guid("2a3531a9-fc95-4952-8839-e52c2b587c97"), new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5315), "Bolsa", false, new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5332), "Alma" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: new Guid("21095b0c-44aa-42b6-aa7d-657325868606"));

            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2a3531a9-fc95-4952-8839-e52c2b587c97"));
        }
    }
}
