using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esercizio1.Migrations
{
    /// <inheritdoc />
    public partial class RelacionStudenteCorso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studente_Corso",
                columns: table => new
                {
                    StudenteId = table.Column<int>(type: "int", nullable: false),
                    CorsoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente_Corso", x => new { x.StudenteId, x.CorsoId });
                    table.ForeignKey(
                        name: "FK_Studente_Corso_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studente_Corso_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Studente_Corso_CorsoId",
                table: "Studente_Corso",
                column: "CorsoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studente_Corso");
        }
    }
}
