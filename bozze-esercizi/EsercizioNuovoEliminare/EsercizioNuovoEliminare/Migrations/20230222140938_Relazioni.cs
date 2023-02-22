using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsercizioNuovoEliminare.Migrations
{
    /// <inheritdoc />
    public partial class Relazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDiNascita",
                table: "Studenti",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorsoTotaleId",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClaseId",
                table: "Postazioni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Postazioni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudenteId",
                table: "Postazioni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInizio",
                table: "Materie",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorsoTotaleId",
                table: "Materie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Materie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDiNascita",
                table: "Docenti",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inizio",
                table: "Corsi_Totali",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScuolaId",
                table: "Corsi_Totali",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Clasi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScuolaId",
                table: "Clasi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MateriaStudente",
                columns: table => new
                {
                    MaterieId = table.Column<int>(type: "int", nullable: false),
                    StudenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaStudente", x => new { x.MaterieId, x.StudenteId });
                    table.ForeignKey(
                        name: "FK_MateriaStudente_Materie_MaterieId",
                        column: x => x.MaterieId,
                        principalTable: "Materie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaStudente_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_CorsoTotaleId",
                table: "Studenti",
                column: "CorsoTotaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Postazioni_ClaseId",
                table: "Postazioni",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Postazioni_DocenteId",
                table: "Postazioni",
                column: "DocenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postazioni_StudenteId",
                table: "Postazioni",
                column: "StudenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materie_CorsoTotaleId",
                table: "Materie",
                column: "CorsoTotaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Materie_DocenteId",
                table: "Materie",
                column: "DocenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_Totali_ScuolaId",
                table: "Corsi_Totali",
                column: "ScuolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasi_MateriaId",
                table: "Clasi",
                column: "MateriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clasi_ScuolaId",
                table: "Clasi",
                column: "ScuolaId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaStudente_StudenteId",
                table: "MateriaStudente",
                column: "StudenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasi_Materie_MateriaId",
                table: "Clasi",
                column: "MateriaId",
                principalTable: "Materie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clasi_Scuole_ScuolaId",
                table: "Clasi",
                column: "ScuolaId",
                principalTable: "Scuole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Corsi_Totali_Scuole_ScuolaId",
                table: "Corsi_Totali",
                column: "ScuolaId",
                principalTable: "Scuole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materie_Corsi_Totali_CorsoTotaleId",
                table: "Materie",
                column: "CorsoTotaleId",
                principalTable: "Corsi_Totali",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materie_Docenti_DocenteId",
                table: "Materie",
                column: "DocenteId",
                principalTable: "Docenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postazioni_Clasi_ClaseId",
                table: "Postazioni",
                column: "ClaseId",
                principalTable: "Clasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postazioni_Docenti_DocenteId",
                table: "Postazioni",
                column: "DocenteId",
                principalTable: "Docenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postazioni_Studenti_StudenteId",
                table: "Postazioni",
                column: "StudenteId",
                principalTable: "Studenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Corsi_Totali_CorsoTotaleId",
                table: "Studenti",
                column: "CorsoTotaleId",
                principalTable: "Corsi_Totali",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasi_Materie_MateriaId",
                table: "Clasi");

            migrationBuilder.DropForeignKey(
                name: "FK_Clasi_Scuole_ScuolaId",
                table: "Clasi");

            migrationBuilder.DropForeignKey(
                name: "FK_Corsi_Totali_Scuole_ScuolaId",
                table: "Corsi_Totali");

            migrationBuilder.DropForeignKey(
                name: "FK_Materie_Corsi_Totali_CorsoTotaleId",
                table: "Materie");

            migrationBuilder.DropForeignKey(
                name: "FK_Materie_Docenti_DocenteId",
                table: "Materie");

            migrationBuilder.DropForeignKey(
                name: "FK_Postazioni_Clasi_ClaseId",
                table: "Postazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Postazioni_Docenti_DocenteId",
                table: "Postazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Postazioni_Studenti_StudenteId",
                table: "Postazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Corsi_Totali_CorsoTotaleId",
                table: "Studenti");

            migrationBuilder.DropTable(
                name: "MateriaStudente");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_CorsoTotaleId",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Postazioni_ClaseId",
                table: "Postazioni");

            migrationBuilder.DropIndex(
                name: "IX_Postazioni_DocenteId",
                table: "Postazioni");

            migrationBuilder.DropIndex(
                name: "IX_Postazioni_StudenteId",
                table: "Postazioni");

            migrationBuilder.DropIndex(
                name: "IX_Materie_CorsoTotaleId",
                table: "Materie");

            migrationBuilder.DropIndex(
                name: "IX_Materie_DocenteId",
                table: "Materie");

            migrationBuilder.DropIndex(
                name: "IX_Corsi_Totali_ScuolaId",
                table: "Corsi_Totali");

            migrationBuilder.DropIndex(
                name: "IX_Clasi_MateriaId",
                table: "Clasi");

            migrationBuilder.DropIndex(
                name: "IX_Clasi_ScuolaId",
                table: "Clasi");

            migrationBuilder.DropColumn(
                name: "CorsoTotaleId",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "ClaseId",
                table: "Postazioni");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Postazioni");

            migrationBuilder.DropColumn(
                name: "StudenteId",
                table: "Postazioni");

            migrationBuilder.DropColumn(
                name: "CorsoTotaleId",
                table: "Materie");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Materie");

            migrationBuilder.DropColumn(
                name: "ScuolaId",
                table: "Corsi_Totali");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Clasi");

            migrationBuilder.DropColumn(
                name: "ScuolaId",
                table: "Clasi");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDiNascita",
                table: "Studenti",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInizio",
                table: "Materie",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDiNascita",
                table: "Docenti",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inizio",
                table: "Corsi_Totali",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
