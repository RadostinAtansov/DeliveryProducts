using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class componentdivideCityAndPlaceInStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceInStorageAndCity",
                table: "Components",
                newName: "PlaceInStorage");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "PlaceInStorage",
                table: "Components",
                newName: "PlaceInStorageAndCity");
        }
    }
}
