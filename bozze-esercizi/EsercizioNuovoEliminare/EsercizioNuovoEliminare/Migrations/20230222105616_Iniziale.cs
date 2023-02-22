using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EsercizioNuovoEliminare.Migrations
{
    /// <inheritdoc />
    public partial class Iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasi", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Corsi_Totali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descrizione = table.Column<string>(type: "longtext", nullable: true),
                    Inizio = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    InCorso = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Ore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi_Totali", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Cognome = table.Column<string>(type: "longtext", nullable: false),
                    OreDilavoro = table.Column<int>(type: "int", nullable: true),
                    Indirizzo = table.Column<string>(type: "longtext", nullable: true),
                    Citta = table.Column<string>(type: "longtext", nullable: true),
                    DataDiNascita = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nazionalita = table.Column<string>(type: "longtext", nullable: true),
                    InCorso = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descrizione = table.Column<string>(type: "longtext", nullable: true),
                    Ore = table.Column<int>(type: "int", nullable: true),
                    DataInizio = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    InCorso = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Postazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postazioni", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Scuole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Indirizzo = table.Column<string>(type: "longtext", nullable: true),
                    Citta = table.Column<string>(type: "longtext", nullable: true),
                    Telefono = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    SitoWeb = table.Column<string>(type: "longtext", nullable: true),
                    Storia = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scuole", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Cognome = table.Column<string>(type: "longtext", nullable: false),
                    Anni = table.Column<int>(type: "int", nullable: false),
                    Indirizzo = table.Column<string>(type: "longtext", nullable: true),
                    Citta = table.Column<string>(type: "longtext", nullable: true),
                    DataDiNascita = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nazionalita = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clasi");

            migrationBuilder.DropTable(
                name: "Corsi_Totali");

            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropTable(
                name: "Postazioni");

            migrationBuilder.DropTable(
                name: "Scuole");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
