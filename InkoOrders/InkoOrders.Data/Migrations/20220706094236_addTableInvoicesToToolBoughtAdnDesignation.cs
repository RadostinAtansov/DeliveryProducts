using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class addTableInvoicesToToolBoughtAdnDesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceInStorageAndCity",
                table: "TooldBoughtByInko",
                newName: "PlaceInStorage");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "TooldBoughtByInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "TooldBoughtByInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ToolBoughtByInkoId",
                table: "TooldBoughtByInko",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TooldBoughtByInko_ToolBoughtByInkoId",
                table: "TooldBoughtByInko",
                column: "ToolBoughtByInkoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TooldBoughtByInko_TooldBoughtByInko_ToolBoughtByInkoId",
                table: "TooldBoughtByInko",
                column: "ToolBoughtByInkoId",
                principalTable: "TooldBoughtByInko",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TooldBoughtByInko_TooldBoughtByInko_ToolBoughtByInkoId",
                table: "TooldBoughtByInko");

            migrationBuilder.DropIndex(
                name: "IX_TooldBoughtByInko_ToolBoughtByInkoId",
                table: "TooldBoughtByInko");

            migrationBuilder.DropColumn(
                name: "City",
                table: "TooldBoughtByInko");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "TooldBoughtByInko");

            migrationBuilder.DropColumn(
                name: "ToolBoughtByInkoId",
                table: "TooldBoughtByInko");

            migrationBuilder.RenameColumn(
                name: "PlaceInStorage",
                table: "TooldBoughtByInko",
                newName: "PlaceInStorageAndCity");
        }
    }
}
