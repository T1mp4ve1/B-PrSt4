using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prigione.Migrations
{
    /// <inheritdoc />
    public partial class adt43stsrt : Migration
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
                    Descrizione = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violazioni", x => x.ViolazioneID);
                });

            migrationBuilder.CreateTable(
                name: "VerbaliTest",
                columns: table => new
                {
                    VerbaleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateOnly>(type: "date", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVerbale = table.Column<DateOnly>(type: "date", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    TrasgressoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViolazioneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbaliTest", x => x.VerbaleID);
                    table.ForeignKey(
                        name: "FK_VerbaliTest_Trasgressori_TrasgressoreID",
                        column: x => x.TrasgressoreID,
                        principalTable: "Trasgressori",
                        principalColumn: "TrasgressoreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerbaliTest_Violazioni_ViolazioneID",
                        column: x => x.ViolazioneID,
                        principalTable: "Violazioni",
                        principalColumn: "ViolazioneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerbaliTest_TrasgressoreID",
                table: "VerbaliTest",
                column: "TrasgressoreID");

            migrationBuilder.CreateIndex(
                name: "IX_VerbaliTest_ViolazioneID",
                table: "VerbaliTest",
                column: "ViolazioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerbaliTest");

            migrationBuilder.DropTable(
                name: "Trasgressori");

            migrationBuilder.DropTable(
                name: "Violazioni");
        }
    }
}
