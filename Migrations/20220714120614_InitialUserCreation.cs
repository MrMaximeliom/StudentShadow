using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentShadow.Migrations
{
    public partial class InitialUserCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "User full name"),
                    UserType = table.Column<int>(type: "int", maxLength: 8, nullable: false, comment: "User type"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Username"),
                    Password = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "User password"),
                    Gender = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "User gender"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "User email"),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "User primary phone"),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "User secondary phone"),
                    Image = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true, comment: "User image"),
                    QRCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "User QR Code")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
