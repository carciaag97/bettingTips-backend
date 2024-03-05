using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResellBackendCore.Migrations
{
    /// <inheritdoc />
    public partial class TicketModifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Tickets");
        }
    }
}
