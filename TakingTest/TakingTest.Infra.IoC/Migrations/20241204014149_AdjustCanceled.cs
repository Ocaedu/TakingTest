using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakingTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCanceled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "Sales");

            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "SalesProduct",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "SalesProduct");

            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
