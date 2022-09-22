using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class updatesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breed",
                table: "PetOwners");

            migrationBuilder.DropColumn(
                name: "color",
                table: "PetOwners");

            migrationBuilder.DropColumn(
                name: "petOwner",
                table: "PetOwners");

            migrationBuilder.RenameColumn(
                name: "petCount",
                table: "Pets",
                newName: "petOwner");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "Pets",
                newName: "checkedInAt");

            migrationBuilder.RenameColumn(
                name: "checkedInAt",
                table: "PetOwners",
                newName: "emailAddress");

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
                newName: "petCount");

            migrationBuilder.RenameColumn(
                name: "checkedInAt",
                table: "Pets",
                newName: "emailAddress");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "PetOwners",
                newName: "checkedInAt");

            migrationBuilder.AddColumn<int>(
                name: "breed",
                table: "PetOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "color",
                table: "PetOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "petOwner",
                table: "PetOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
