using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.API.Migrations
{
    public partial class AddedOnModelCreate : Migration
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

            migrationBuilder.InsertData(
                table: "SpacePorts",
                columns: new[] { "SpacePortID", "Status" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ParkingLotID", "SpaceportID", "Status", "VisitorID" },
                values: new object[,]
                {
                    { 1, 1, 0, null },
                    { 2, 1, 0, null },
                    { 3, 1, 0, null },
                    { 4, 1, 0, null },
                    { 5, 1, 0, null }
                });

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

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SpacePorts",
                keyColumn: "SpacePortID",
                keyValue: 1);

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
