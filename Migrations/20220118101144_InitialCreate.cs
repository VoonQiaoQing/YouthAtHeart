using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthAtHeart.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeInfo",
                columns: table => new
                {
                    homeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    homeOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeInfo", x => x.homeId);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    test = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirmPass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopInfo",
                columns: table => new
                {
                    wsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    wsCoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsEnvImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsMainInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsLocationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsLocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wsLessonSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    regEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    firstLesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endLesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    wsPrice = table.Column<double>(type: "float", nullable: false),
                    wsTotalAttendees = table.Column<int>(type: "int", nullable: false),
                    wsRating = table.Column<double>(type: "float", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    teacherId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopInfo", x => x.wsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeInfo");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WorkshopInfo");
        }
    }
}
