using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class addTableInvoiceToToolCreatedByInkoAndDesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceInStorageAndCity",
                table: "ToolCreatedByInko",
                newName: "PlaceInStorage");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ToolCreatedByInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "ToolCreatedByInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InvoicesStorageToolCreatedByInko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoughtCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeWhenBoughtOnInvoice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolCreatedByInkoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesStorageToolCreatedByInko", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicesStorageToolCreatedByInko_ToolCreatedByInko_ToolCreatedByInkoId",
                        column: x => x.ToolCreatedByInkoId,
                        principalTable: "ToolCreatedByInko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesStorageToolCreatedByInko_ToolCreatedByInkoId",
                table: "InvoicesStorageToolCreatedByInko",
                column: "ToolCreatedByInkoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicesStorageToolCreatedByInko");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ToolCreatedByInko");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "ToolCreatedByInko");

            migrationBuilder.RenameColumn(
                name: "PlaceInStorage",
                table: "ToolCreatedByInko",
                newName: "PlaceInStorageAndCity");
        }
    }
}
