using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakingTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SaleProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSale");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Sales",
                newName: "Canceled");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Sales",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SalesProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<long>(type: "INTEGER", nullable: false),
                    Discount = table.Column<long>(type: "INTEGER", nullable: false),
                    SaleId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesProduct_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesProduct_ProductId",
                table: "SalesProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProduct_SaleId",
                table: "SalesProduct",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesProduct");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "Canceled",
                table: "Sales",
                newName: "Discount");

            migrationBuilder.CreateTable(
                name: "ProductSale",
                columns: table => new
                {
                    ProductsId = table.Column<long>(type: "INTEGER", nullable: false),
                    SalesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSale", x => new { x.ProductsId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_ProductSale_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSale_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SalesId",
                table: "ProductSale",
                column: "SalesId");
        }
    }
}
