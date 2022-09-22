using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class ChangedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetBreedType",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "checkedIn",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "ownedBy",
                table: "Pets",
                newName: "petOwner");

            migrationBuilder.RenameColumn(
                name: "PetColorType",
                table: "Pets",
                newName: "checkedInAt");

            migrationBuilder.AddColumn<int>(
                name: "breed",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "color",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwner",
                table: "Pets",
                newName: "ownedBy");

            migrationBuilder.RenameColumn(
                name: "checkedInAt",
                table: "Pets",
                newName: "PetColorType");

            migrationBuilder.AddColumn<string>(
                name: "PetBreedType",
                table: "Pets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "checkedIn",
                table: "Pets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
