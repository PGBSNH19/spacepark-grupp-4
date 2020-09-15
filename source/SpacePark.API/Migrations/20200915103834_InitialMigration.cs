using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpacePorts",
                columns: table => new
                {
                    SpacePortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacePorts", x => x.SpacePortID);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payed = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorID);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    ParkingLotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpacePortID = table.Column<int>(nullable: false),
                    ParkingLotOccupied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.ParkingLotID);
                    table.ForeignKey(
                        name: "FK_ParkingLots_SpacePorts_SpacePortID",
                        column: x => x.SpacePortID,
                        principalTable: "SpacePorts",
                        principalColumn: "SpacePortID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorParkings",
                columns: table => new
                {
                    VistorParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotID = table.Column<int>(nullable: false),
                    VisitorID = table.Column<int>(nullable: false),
                    DateOfEntry = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorParkings", x => x.VistorParkingID);
                    table.ForeignKey(
                        name: "FK_VisitorParkings_ParkingLots_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "ParkingLots",
                        principalColumn: "ParkingLotID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorParkings_Visitors_VisitorID",
                        column: x => x.VisitorID,
                        principalTable: "Visitors",
                        principalColumn: "VisitorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParkings_ParkingLotID",
                table: "VisitorParkings",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParkings_VisitorID",
                table: "VisitorParkings",
                column: "VisitorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorParkings");

            migrationBuilder.DropTable(
                name: "ParkingLots");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "SpacePorts");
        }
    }
}
