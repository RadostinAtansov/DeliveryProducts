using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class ChangeMaterialCityAndStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceInStorageAndCity",
                table: "MaterialsInInko",
                newName: "PlaceInStorage");

            migrationBuilder.AlterColumn<int>(
                name: "Quаntity",
                table: "MaterialsInInko",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "MaterialsInInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "MaterialsInInko");

            migrationBuilder.RenameColumn(
                name: "PlaceInStorage",
                table: "MaterialsInInko",
                newName: "PlaceInStorageAndCity");

            migrationBuilder.AlterColumn<int>(
                name: "Quаntity",
                table: "MaterialsInInko",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
