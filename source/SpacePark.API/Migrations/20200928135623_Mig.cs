using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.API.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.RenameColumn(
                name: "SpacePortID",
                table: "ParkingLots",
                newName: "SpaceportID");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "ParkingLots",
                newName: "IX_ParkingLots_SpaceportID");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceportID",
                table: "ParkingLots",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpaceportID",
                table: "ParkingLots",
                column: "SpaceportID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpaceportID",
                table: "ParkingLots");

            migrationBuilder.RenameColumn(
                name: "SpaceportID",
                table: "ParkingLots",
                newName: "SpacePortID");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingLots_SpaceportID",
                table: "ParkingLots",
                newName: "IX_ParkingLots_SpacePortID");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingLots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
