using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class addPhotosTableToComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicesStorageToolCreatedByInko");

            migrationBuilder.CreateTable(
                name: "ComponentsListPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentsListPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentsListPhotos_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentsListPhotos_ComponentId",
                table: "ComponentsListPhotos",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentsListPhotos");

            migrationBuilder.CreateTable(
                name: "InvoicesStorageToolCreatedByInko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolCreatedByInkoId = table.Column<int>(type: "int", nullable: false),
                    BoughtCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TimeWhenBoughtOnInvoice = table.Column<DateTime>(type: "datetime2", nullable: false)
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
    }
}
