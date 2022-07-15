using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentShadow.Migrations
{
    public partial class InitialWalletCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "QRCode"),
                    Amount = table.Column<decimal>(type: "decimal(9,3)", precision: 9, scale: 3, nullable: false, comment: "Wallet amount"),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "LastUpdated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
