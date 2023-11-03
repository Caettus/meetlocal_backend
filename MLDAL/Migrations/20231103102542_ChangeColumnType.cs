using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Gatherings\" ALTER COLUMN \"GatheringDateTime\" TYPE timestamp with time zone USING to_timestamp(\"GatheringDateTime\", 'YYYY-MM-DD HH24:MI:SS')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Gatherings\" ALTER COLUMN \"GatheringDateTime\" TYPE text");
        }
    }
}
