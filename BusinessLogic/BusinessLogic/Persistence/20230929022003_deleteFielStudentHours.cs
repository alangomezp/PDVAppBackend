using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessLogic.BusinessLogic.Persistence
{
    /// <inheritdoc />
    public partial class deleteFielStudentHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: new Guid("21095b0c-44aa-42b6-aa7d-657325868606"));

            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2a3531a9-fc95-4952-8839-e52c2b587c97"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "StudentHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "FundAccounts",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "LastUpdatedDate", "Owner" },
                values: new object[,]
                {
                    { new Guid("04318a08-9ac1-4b48-8448-768a03d25217"), new DateTime(2023, 9, 28, 22, 20, 2, 930, DateTimeKind.Local).AddTicks(2258), "Efectivo", false, new DateTime(2023, 9, 28, 22, 20, 2, 930, DateTimeKind.Local).AddTicks(2258), "Omayra" },
                    { new Guid("fe14c08d-5203-4c23-bd66-f40645c36d23"), new DateTime(2023, 9, 28, 22, 20, 2, 930, DateTimeKind.Local).AddTicks(2243), "Bolsa", false, new DateTime(2023, 9, 28, 22, 20, 2, 930, DateTimeKind.Local).AddTicks(2254), "Alma" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: new Guid("04318a08-9ac1-4b48-8448-768a03d25217"));

            migrationBuilder.DeleteData(
                table: "FundAccounts",
                keyColumn: "Id",
                keyValue: new Guid("fe14c08d-5203-4c23-bd66-f40645c36d23"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentHours");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "StudentHours");

            migrationBuilder.InsertData(
                table: "FundAccounts",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "LastUpdatedDate", "Owner" },
                values: new object[,]
                {
                    { new Guid("21095b0c-44aa-42b6-aa7d-657325868606"), new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5338), "Efectivo", false, new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5339), "Omayra" },
                    { new Guid("2a3531a9-fc95-4952-8839-e52c2b587c97"), new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5315), "Bolsa", false, new DateTime(2023, 9, 3, 18, 50, 5, 831, DateTimeKind.Local).AddTicks(5332), "Alma" }
                });
        }
    }
}
