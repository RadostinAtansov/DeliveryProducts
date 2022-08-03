using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class addTableInvoicesToToolBoughtAdnDesignation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesStorageMaterial_MaterialsInInko_MaterialId",
                table: "InvoicesStorageMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesStorageWare_WaresInko_WareInkoId",
                table: "InvoicesStorageWare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesStorageWare",
                table: "InvoicesStorageWare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesStorageMaterial",
                table: "InvoicesStorageMaterial");

            migrationBuilder.RenameTable(
                name: "InvoicesStorageWare",
                newName: "InvoicesStorageWares");

            migrationBuilder.RenameTable(
                name: "InvoicesStorageMaterial",
                newName: "InvoicesStorageMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesStorageWare_WareInkoId",
                table: "InvoicesStorageWares",
                newName: "IX_InvoicesStorageWares_WareInkoId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesStorageMaterial_MaterialId",
                table: "InvoicesStorageMaterials",
                newName: "IX_InvoicesStorageMaterials_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesStorageWares",
                table: "InvoicesStorageWares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesStorageMaterials",
                table: "InvoicesStorageMaterials",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InvoicesStorageToolBoughtByInkos",
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
                    ToolBoughtByInkoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesStorageToolBoughtByInkos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicesStorageToolBoughtByInkos_TooldBoughtByInko_ToolBoughtByInkoId",
                        column: x => x.ToolBoughtByInkoId,
                        principalTable: "TooldBoughtByInko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesStorageToolBoughtByInkos_ToolBoughtByInkoId",
                table: "InvoicesStorageToolBoughtByInkos",
                column: "ToolBoughtByInkoId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesStorageMaterials_MaterialsInInko_MaterialId",
                table: "InvoicesStorageMaterials",
                column: "MaterialId",
                principalTable: "MaterialsInInko",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesStorageWares_WaresInko_WareInkoId",
                table: "InvoicesStorageWares",
                column: "WareInkoId",
                principalTable: "WaresInko",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesStorageMaterials_MaterialsInInko_MaterialId",
                table: "InvoicesStorageMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesStorageWares_WaresInko_WareInkoId",
                table: "InvoicesStorageWares");

            migrationBuilder.DropTable(
                name: "InvoicesStorageToolBoughtByInkos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesStorageWares",
                table: "InvoicesStorageWares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesStorageMaterials",
                table: "InvoicesStorageMaterials");

            migrationBuilder.RenameTable(
                name: "InvoicesStorageWares",
                newName: "InvoicesStorageWare");

            migrationBuilder.RenameTable(
                name: "InvoicesStorageMaterials",
                newName: "InvoicesStorageMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesStorageWares_WareInkoId",
                table: "InvoicesStorageWare",
                newName: "IX_InvoicesStorageWare_WareInkoId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesStorageMaterials_MaterialId",
                table: "InvoicesStorageMaterial",
                newName: "IX_InvoicesStorageMaterial_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesStorageWare",
                table: "InvoicesStorageWare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesStorageMaterial",
                table: "InvoicesStorageMaterial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesStorageMaterial_MaterialsInInko_MaterialId",
                table: "InvoicesStorageMaterial",
                column: "MaterialId",
                principalTable: "MaterialsInInko",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesStorageWare_WaresInko_WareInkoId",
                table: "InvoicesStorageWare",
                column: "WareInkoId",
                principalTable: "WaresInko",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
