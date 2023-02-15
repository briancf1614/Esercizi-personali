using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eliminar.Migrations
{
    /// <inheritdoc />
    public partial class RelacionMatricolaStudente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatricolaId",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_MatricolaId",
                table: "Studenti",
                column: "MatricolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Matricole_MatricolaId",
                table: "Studenti",
                column: "MatricolaId",
                principalTable: "Matricole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Matricole_MatricolaId",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_MatricolaId",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "MatricolaId",
                table: "Studenti");
        }
    }
}
