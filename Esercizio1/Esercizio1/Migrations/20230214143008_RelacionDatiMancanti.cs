using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esercizio1.Migrations
{
    /// <inheritdoc />
    public partial class RelacionDatiMancanti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScuolaId",
                table: "Professori",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessoreId",
                table: "Corsi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professori_ScuolaId",
                table: "Professori",
                column: "ScuolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_ProfessoreId",
                table: "Corsi",
                column: "ProfessoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Corsi_Professori_ProfessoreId",
                table: "Corsi",
                column: "ProfessoreId",
                principalTable: "Professori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professori_Scuole_ScuolaId",
                table: "Professori",
                column: "ScuolaId",
                principalTable: "Scuole",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corsi_Professori_ProfessoreId",
                table: "Corsi");

            migrationBuilder.DropForeignKey(
                name: "FK_Professori_Scuole_ScuolaId",
                table: "Professori");

            migrationBuilder.DropIndex(
                name: "IX_Professori_ScuolaId",
                table: "Professori");

            migrationBuilder.DropIndex(
                name: "IX_Corsi_ProfessoreId",
                table: "Corsi");

            migrationBuilder.DropColumn(
                name: "ScuolaId",
                table: "Professori");

            migrationBuilder.DropColumn(
                name: "ProfessoreId",
                table: "Corsi");
        }
    }
}
