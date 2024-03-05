using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResellBackendCore.Migrations
{
    /// <inheritdoc />
    public partial class Modificationssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateType",
                table: "Tickets",
                newName: "StateTypeId");

            migrationBuilder.RenameColumn(
                name: "NewsType",
                table: "News",
                newName: "NewsTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateTypeId",
                table: "Tickets",
                newName: "StateType");

            migrationBuilder.RenameColumn(
                name: "NewsTypeId",
                table: "News",
                newName: "NewsType");
        }
    }
}
