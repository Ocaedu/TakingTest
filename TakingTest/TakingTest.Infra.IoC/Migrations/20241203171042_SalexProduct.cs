using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakingTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SalexProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Sales_SaleId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SaleId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Product");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Sales",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Product_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Product_ProductId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ProductId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sales");

            migrationBuilder.AddColumn<long>(
                name: "SaleId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SaleId",
                table: "Product",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Sales_SaleId",
                table: "Product",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}
