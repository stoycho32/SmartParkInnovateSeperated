using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class FixingParkingSpotsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotOccupations_parkingSpots_ParkingSpotId",
                table: "ParkingSpotOccupations");

            migrationBuilder.DropForeignKey(
                name: "FK_parkingSpots_Vehicles_OccupationVehicleId",
                table: "parkingSpots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parkingSpots",
                table: "parkingSpots");

            migrationBuilder.RenameTable(
                name: "parkingSpots",
                newName: "ParkingSpots");

            migrationBuilder.RenameIndex(
                name: "IX_parkingSpots_OccupationVehicleId",
                table: "ParkingSpots",
                newName: "IX_ParkingSpots_OccupationVehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpots",
                table: "ParkingSpots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotOccupations_ParkingSpots_ParkingSpotId",
                table: "ParkingSpotOccupations",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Vehicles_OccupationVehicleId",
                table: "ParkingSpots",
                column: "OccupationVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotOccupations_ParkingSpots_ParkingSpotId",
                table: "ParkingSpotOccupations");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Vehicles_OccupationVehicleId",
                table: "ParkingSpots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpots",
                table: "ParkingSpots");

            migrationBuilder.RenameTable(
                name: "ParkingSpots",
                newName: "parkingSpots");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSpots_OccupationVehicleId",
                table: "parkingSpots",
                newName: "IX_parkingSpots_OccupationVehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parkingSpots",
                table: "parkingSpots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotOccupations_parkingSpots_ParkingSpotId",
                table: "ParkingSpotOccupations",
                column: "ParkingSpotId",
                principalTable: "parkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parkingSpots_Vehicles_OccupationVehicleId",
                table: "parkingSpots",
                column: "OccupationVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
