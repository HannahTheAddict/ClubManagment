using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HannahElSayed0523003.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachID);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coaches",
                        principalColumn: "CoachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTeam",
                columns: table => new
                {
                    CompetitionsCompetitionID = table.Column<int>(type: "int", nullable: false),
                    TeamsTeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTeam", x => new { x.CompetitionsCompetitionID, x.TeamsTeamID });
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Competitions_CompetitionsCompetitionID",
                        column: x => x.CompetitionsCompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionTeam_Teams_TeamsTeamID",
                        column: x => x.TeamsTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "CoachID", "CoachName", "ExperienceYears", "Specialization" },
                values: new object[,]
                {
                    { 1, "lama", 3, "C#" },
                    { 2, "salma", 4, "C++" },
                    { 3, "laimya", 5, "F#" },
                    { 4, "slama", 10, "WebAPI" },
                    { 5, "hanna", 3, "C#" }
                });

            migrationBuilder.InsertData(
                table: "Competitions",
                columns: new[] { "CompetitionID", "CompetitionName", "Date", "Location" },
                values: new object[,]
                {
                    { 1, "app dev", new DateTime(2025, 10, 10, 7, 25, 1, 880, DateTimeKind.Utc).AddTicks(9952), "Cairo" },
                    { 2, "web dev", new DateTime(2025, 9, 30, 7, 25, 1, 880, DateTimeKind.Utc).AddTicks(9958), "Giza" },
                    { 3, "desktop dev", new DateTime(2025, 9, 20, 7, 25, 1, 880, DateTimeKind.Utc).AddTicks(9960), "Alexandria" },
                    { 4, "mobile dev", new DateTime(2025, 9, 25, 7, 25, 1, 880, DateTimeKind.Utc).AddTicks(9961), "Giza" },
                    { 5, "lol", new DateTime(2025, 9, 20, 7, 25, 1, 880, DateTimeKind.Utc).AddTicks(9963), "Cairo" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "City", "CoachID", "TeamName" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, "the wtv" },
                    { 2, "Giza", 2, "the lll" },
                    { 3, "Cairo", 3, "idk" },
                    { 4, "Alexandria", 4, "idk2" },
                    { 5, "Giza", 5, "greeners" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Age", "PlayerName", "Position", "TeamID" },
                values: new object[,]
                {
                    { 1, 17, "ahmed", "leader", 1 },
                    { 2, 18, "mohamed", "member", 2 },
                    { 3, 19, "mahmoud", "leader", 3 },
                    { 4, 15, "salama", "member", 4 },
                    { 5, 17, "yousef", "member", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTeam_TeamsTeamID",
                table: "CompetitionTeam",
                column: "TeamsTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachID",
                table: "Teams",
                column: "CoachID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamName",
                table: "Teams",
                column: "TeamName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionTeam");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Coaches");
        }
    }
}
