using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class fixSelfreferenceToolBoughtInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TooldBoughtByInko_TooldBoughtByInko_ToolBoughtByInkoId",
                table: "TooldBoughtByInko");

            migrationBuilder.DropIndex(
                name: "IX_TooldBoughtByInko_ToolBoughtByInkoId",
                table: "TooldBoughtByInko");

            migrationBuilder.DropColumn(
                name: "ToolBoughtByInkoId",
                table: "TooldBoughtByInko");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
