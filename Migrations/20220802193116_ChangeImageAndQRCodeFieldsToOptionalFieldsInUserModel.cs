using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentShadow.Migrations
{
    public partial class ChangeQRCodeFieldToOptionalFieldInUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QRCode",
                schema: "security",
                table: "Users",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                comment: "User QR Code",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "User QR Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QRCode",
                schema: "security",
                table: "Users",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                comment: "User QR Code",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true,
                oldComment: "User QR Code");
        }
    }
}
