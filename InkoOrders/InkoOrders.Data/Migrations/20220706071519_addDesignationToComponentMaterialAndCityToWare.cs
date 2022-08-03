using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class addDesignationToComponentMaterialAndCityToWare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaceInStorageAndCity",
                table: "WaresInko",
                newName: "PlaceInStorage");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "WaresInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "WaresInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "MaterialsInInko",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Components",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "WaresInko");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "WaresInko");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "MaterialsInInko");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "PlaceInStorage",
                table: "WaresInko",
                newName: "PlaceInStorageAndCity");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
