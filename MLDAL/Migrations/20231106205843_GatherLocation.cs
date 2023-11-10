using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLDAL.Migrations
{
    /// <inheritdoc />
    public partial class GatherLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GatheringLocation",
                table: "Gatherings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GatheringLocation",
                table: "Gatherings");
        }
    }
}
