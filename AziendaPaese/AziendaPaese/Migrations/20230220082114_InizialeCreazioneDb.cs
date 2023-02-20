using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AziendaPaese.Migrations
{
    /// <inheritdoc />
    public partial class InizialeCreazioneDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aziende",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeDirettore = table.Column<string>(type: "longtext", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Indirizzo = table.Column<string>(type: "longtext", nullable: false),
                    Citta = table.Column<string>(type: "longtext", nullable: false),
                    Provincia = table.Column<string>(type: "longtext", nullable: false),
                    Cap = table.Column<string>(type: "longtext", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "longtext", nullable: false),
                    Attiva = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInizioAttivita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aziende", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bustepaghe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Banca = table.Column<string>(type: "longtext", nullable: false),
                    Pagata = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bustepaghe", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dipendenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Cognome = table.Column<string>(type: "longtext", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "longtext", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "longtext", nullable: false),
                    Iban = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Attivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInizioAttivita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendenti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Progetti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descrizione = table.Column<string>(type: "longtext", nullable: false),
                    Attivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInizioAttivita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progetti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reparti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descrizione = table.Column<string>(type: "longtext", nullable: false),
                    Attivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInizioAttivita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReportiGiornalieri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descrizione = table.Column<string>(type: "longtext", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OreLavorate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportiGiornalieri", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stagisti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Cognome = table.Column<string>(type: "longtext", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "longtext", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "longtext", nullable: false),
                    Iban = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Attivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInizioAttivita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stagisti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SupervisoriReparto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Cognome = table.Column<string>(type: "longtext", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "longtext", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "longtext", nullable: false),
                    Iban = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Attivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInizioAttivita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisoriReparto", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aziende");

            migrationBuilder.DropTable(
                name: "Bustepaghe");

            migrationBuilder.DropTable(
                name: "Dipendenti");

            migrationBuilder.DropTable(
                name: "Progetti");

            migrationBuilder.DropTable(
                name: "Reparti");

            migrationBuilder.DropTable(
                name: "ReportiGiornalieri");

            migrationBuilder.DropTable(
                name: "Stagisti");

            migrationBuilder.DropTable(
                name: "SupervisoriReparto");
        }
    }
}
