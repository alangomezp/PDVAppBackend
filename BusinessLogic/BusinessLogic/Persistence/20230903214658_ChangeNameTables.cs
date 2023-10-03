using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.BusinessLogic.Persistence
{
    /// <inheritdoc />
    public partial class ChangeNameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagFundHours_Students_StudentId",
                table: "BagFundHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fundAccounts",
                table: "fundAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BagFundHours",
                table: "BagFundHours");

            migrationBuilder.RenameTable(
                name: "fundAccounts",
                newName: "FundAccounts");

            migrationBuilder.RenameTable(
                name: "BagFundHours",
                newName: "StudentHours");

            migrationBuilder.RenameIndex(
                name: "IX_BagFundHours_StudentId",
                table: "StudentHours",
                newName: "IX_StudentHours_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundAccounts",
                table: "FundAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHours",
                table: "StudentHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentHours_Students_StudentId",
                table: "StudentHours",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentHours_Students_StudentId",
                table: "StudentHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundAccounts",
                table: "FundAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHours",
                table: "StudentHours");

            migrationBuilder.RenameTable(
                name: "FundAccounts",
                newName: "fundAccounts");

            migrationBuilder.RenameTable(
                name: "StudentHours",
                newName: "BagFundHours");

            migrationBuilder.RenameIndex(
                name: "IX_StudentHours_StudentId",
                table: "BagFundHours",
                newName: "IX_BagFundHours_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fundAccounts",
                table: "fundAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BagFundHours",
                table: "BagFundHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BagFundHours_Students_StudentId",
                table: "BagFundHours",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
