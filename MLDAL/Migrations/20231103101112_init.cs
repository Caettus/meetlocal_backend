using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MLDAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gatherings",
                columns: table => new
                {
                    GatheringId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GatheringName = table.Column<string>(type: "text", nullable: false),
                    GatheringDescription = table.Column<string>(type: "text", nullable: false),
                    GatheringOrganiser = table.Column<string>(type: "text", nullable: false),
                    GatheringDateTime = table.Column<string>(type: "text", nullable: false),
                    GatheringCategory = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatherings", x => x.GatheringId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gatherings");
        }
    }
}
