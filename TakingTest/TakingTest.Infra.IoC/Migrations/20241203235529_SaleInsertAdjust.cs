using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakingTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SaleInsertAdjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesProduct_Sales_SaleId",
                table: "SalesProduct");

            migrationBuilder.AlterColumn<long>(
                name: "SaleId",
                table: "SalesProduct",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesProduct_Sales_SaleId",
                table: "SalesProduct",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesProduct_Sales_SaleId",
                table: "SalesProduct");

            migrationBuilder.AlterColumn<long>(
                name: "SaleId",
                table: "SalesProduct",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesProduct_Sales_SaleId",
                table: "SalesProduct",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}
