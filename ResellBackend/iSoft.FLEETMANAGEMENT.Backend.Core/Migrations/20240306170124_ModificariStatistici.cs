using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResellBackendCore.Migrations
{
    /// <inheritdoc />
    public partial class ModificariStatistici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Statistics");
        }
    }
}
