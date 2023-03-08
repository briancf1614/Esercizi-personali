using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PianetaPersone.Migrations
{
    /// <inheritdoc />
    public partial class RPianetaPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PianetaId",
                table: "Persone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persone_PianetaId",
                table: "Persone",
                column: "PianetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persone_Pianeti_PianetaId",
                table: "Persone",
                column: "PianetaId",
                principalTable: "Pianeti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persone_Pianeti_PianetaId",
                table: "Persone");

            migrationBuilder.DropIndex(
                name: "IX_Persone_PianetaId",
                table: "Persone");

            migrationBuilder.DropColumn(
                name: "PianetaId",
                table: "Persone");
        }
    }
}
