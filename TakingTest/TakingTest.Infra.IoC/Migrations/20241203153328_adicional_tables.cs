using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakingTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicional_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Branch_BranchId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Client_ClientId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branchs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branchs",
                table: "Branchs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Branchs_BranchId",
                table: "Sales",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Branchs_BranchId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branchs",
                table: "Branchs");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "Branchs",
                newName: "Branch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Branch_BranchId",
                table: "Sales",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Client_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
