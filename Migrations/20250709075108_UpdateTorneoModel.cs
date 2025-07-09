using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTorneoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cognome",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IscrittoAlTorneo",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "OrganizzatoreDelTorneo",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Incontri",
                columns: table => new
                {
                    IncontroID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PartecipanteAID = table.Column<int>(type: "INTEGER", nullable: false),
                    PartecipanteBID = table.Column<int>(type: "INTEGER", nullable: false),
                    Giocato = table.Column<bool>(type: "INTEGER", nullable: false),
                    PuntiA = table.Column<int>(type: "INTEGER", nullable: true),
                    PuntiB = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incontri", x => x.IncontroID);
                    table.ForeignKey(
                        name: "FK_Incontri_Users_PartecipanteAID",
                        column: x => x.PartecipanteAID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incontri_Users_PartecipanteBID",
                        column: x => x.PartecipanteBID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incontri_PartecipanteAID",
                table: "Incontri",
                column: "PartecipanteAID");

            migrationBuilder.CreateIndex(
                name: "IX_Incontri_PartecipanteBID",
                table: "Incontri",
                column: "PartecipanteBID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incontri");

            migrationBuilder.DropColumn(
                name: "Cognome",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IscrittoAlTorneo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizzatoreDelTorneo",
                table: "Users");
        }
    }
}
