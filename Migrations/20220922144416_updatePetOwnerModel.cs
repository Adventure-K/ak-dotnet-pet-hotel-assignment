using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class updatePetOwnerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "PetOwners",
                newName: "emailAddress");

            migrationBuilder.AddColumn<int>(
                name: "petCount",
                table: "PetOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "petCount",
                table: "PetOwners");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "PetOwners",
                newName: "email");
        }
    }
}
