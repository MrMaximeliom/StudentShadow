using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentShadow.Migrations
{
    public partial class RemoveUserTypeFieldFromUsersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "security",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                schema: "security",
                table: "Users",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0,
                comment: "User type");
        }
    }
}
