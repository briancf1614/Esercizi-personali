using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eliminar.Migrations
{
    /// <inheritdoc />
    public partial class RelacionStudenteProfessorCorso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorsoProfessore",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    ProfessoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoProfessore", x => new { x.CorsiId, x.ProfessoriId });
                    table.ForeignKey(
                        name: "FK_CorsoProfessore_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoProfessore_Professori_ProfessoriId",
                        column: x => x.ProfessoriId,
                        principalTable: "Professori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CorsoStudente",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    StudentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoStudente", x => new { x.CorsiId, x.StudentiId });
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Studenti_StudentiId",
                        column: x => x.StudentiId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CorsoProfessore_ProfessoriId",
                table: "CorsoProfessore",
                column: "ProfessoriId");

            migrationBuilder.CreateIndex(
                name: "IX_CorsoStudente_StudentiId",
                table: "CorsoStudente",
                column: "StudentiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsoProfessore");

            migrationBuilder.DropTable(
                name: "CorsoStudente");
        }
    }
}
