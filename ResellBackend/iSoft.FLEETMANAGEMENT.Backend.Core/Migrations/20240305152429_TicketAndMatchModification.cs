using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResellBackendCore.Migrations
{
    /// <inheritdoc />
    public partial class TicketAndMatchModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tickets_TicketId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TicketId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "TicketMatches",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMatches", x => new { x.TicketId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_TicketMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketMatches_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketMatches_MatchId",
                table: "TicketMatches",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketMatches");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TicketId",
                table: "Matches",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tickets_TicketId",
                table: "Matches",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
