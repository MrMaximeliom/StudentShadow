using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentShadow.Migrations
{
    public partial class EditingMultipleFelds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GeneralDuides",
                table: "Diseases",
                newName: "GeneralGuides");

            migrationBuilder.AlterColumn<int>(
                name: "DueStatus",
                table: "HomeWorks",
                type: "int",
                maxLength: 100,
                nullable: false,
                comment: "Due status",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Due status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GeneralGuides",
                table: "Diseases",
                newName: "GeneralDuides");

            migrationBuilder.AlterColumn<string>(
                name: "DueStatus",
                table: "HomeWorks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Due status",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100,
                oldComment: "Due status");
        }
    }
}
