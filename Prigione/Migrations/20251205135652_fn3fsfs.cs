using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prigione.Migrations
{
    /// <inheritdoc />
    public partial class fn3fsfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trasgressori",
                columns: table => new
                {
                    TrasgressoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CAP = table.Column<int>(type: "int", nullable: false),
                    CF = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasgressori", x => x.TrasgressoreID);
                });

            migrationBuilder.CreateTable(
                name: "Violazioni",
                columns: table => new
                {
                    ViolazioneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violazioni", x => x.ViolazioneID);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    VerbaleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    TrasgressoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViolazioneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViolazioneID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.VerbaleID);
                    table.ForeignKey(
                        name: "FK_Verbali_Trasgressori_TrasgressoreID",
                        column: x => x.TrasgressoreID,
                        principalTable: "Trasgressori",
                        principalColumn: "TrasgressoreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbali_Violazioni_ViolazioneID1",
                        column: x => x.ViolazioneID1,
                        principalTable: "Violazioni",
                        principalColumn: "ViolazioneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_TrasgressoreID",
                table: "Verbali",
                column: "TrasgressoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_ViolazioneID1",
                table: "Verbali",
                column: "ViolazioneID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Trasgressori");

            migrationBuilder.DropTable(
                name: "Violazioni");
        }
    }
}
