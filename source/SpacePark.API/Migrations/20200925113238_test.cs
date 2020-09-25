using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "ParkingLotOccupied",
                table: "ParkingLots");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ParkingLots");

            migrationBuilder.AddColumn<bool>(
                name: "ParkingLotOccupied",
                table: "ParkingLots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID",
                unique: true);
        }
    }
}
