using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class addTableInvoicesToWare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoicesStorageWare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoughtCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qantity = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeWhenBoughtOnInvoice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareInkoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesStorageWare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicesStorageWare_WaresInko_WareInkoId",
                        column: x => x.WareInkoId,
                        principalTable: "WaresInko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesStorageWare_WareInkoId",
                table: "InvoicesStorageWare",
                column: "WareInkoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicesStorageWare");
        }
    }
}
