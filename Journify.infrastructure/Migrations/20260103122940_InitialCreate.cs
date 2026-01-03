using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Journify.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyJournies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JournyDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyJournies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyJournies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DailyJourneyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_DailyJournies_DailyJourneyId",
                        column: x => x.DailyJourneyId,
                        principalTable: "DailyJournies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "fasdfa@gmail.om", "AQAAAA", "testuser" },
                    { new Guid("e13b5f1e-7c54-4b01-90e6-d701748f0852"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "fasdfasdf@gmail.com", "AQAAABBB", "anotheruser" }
                });

            migrationBuilder.InsertData(
                table: "DailyJournies",
                columns: new[] { "Id", "CreatedAt", "JournyDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2024, 1, 1), new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2024, 1, 1), new Guid("e13b5f1e-7c54-4b01-90e6-d701748f0852") }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "CreatedAt", "DailyJourneyId", "Description", "IsCompleted", "LastUpdatedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4789-9012-3456789abcde"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), "Start your day with a 10-minute meditation session.", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Morning Meditation" },
                    { new Guid("f1e2d3c4-b5a6-4789-9012-3456789fedcb"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), "Reflect on your day and jot down your thoughts in your journal.", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Evening Reflection" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyJournies_UserId",
                table: "DailyJournies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_DailyJourneyId",
                table: "Steps",
                column: "DailyJourneyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "DailyJournies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
