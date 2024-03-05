using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResellBackendCore.Migrations
{
    /// <inheritdoc />
    public partial class MatchModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Matches",
                newName: "StartTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Matches",
                newName: "Hour");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
