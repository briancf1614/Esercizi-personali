using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFBase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTAbleWorkingForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Wokringgexperience_UserId",
                table: "Wokringgexperience",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wokringgexperience_Users_UserId",
                table: "Wokringgexperience",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wokringgexperience_Users_UserId",
                table: "Wokringgexperience");

            migrationBuilder.DropIndex(
                name: "IX_Wokringgexperience_UserId",
                table: "Wokringgexperience");
        }
    }
}
