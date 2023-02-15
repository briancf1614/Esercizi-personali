using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eliminar.Migrations
{
    /// <inheritdoc />
    public partial class RelacionVotoCorso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VotoId",
                table: "Corsi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_VotoId",
                table: "Corsi",
                column: "VotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Corsi_Voti_VotoId",
                table: "Corsi",
                column: "VotoId",
                principalTable: "Voti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corsi_Voti_VotoId",
                table: "Corsi");

            migrationBuilder.DropIndex(
                name: "IX_Corsi_VotoId",
                table: "Corsi");

            migrationBuilder.DropColumn(
                name: "VotoId",
                table: "Corsi");
        }
    }
}
