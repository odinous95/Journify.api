using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagment.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JounreyName",
                table: "DailyJourney",
                newName: "JourneyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JourneyName",
                table: "DailyJourney",
                newName: "JounreyName");
        }
    }
}
