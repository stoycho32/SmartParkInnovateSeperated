using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class SettingUpParkingSpotOccupationAsAProperMappingTableAndAddingTheCollectionsToVehicleAndParkingSpot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpotOccupations",
                table: "ParkingSpotOccupations");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpotOccupations_ParkingSpotId",
                table: "ParkingSpotOccupations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ParkingSpotOccupations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpotOccupations",
                table: "ParkingSpotOccupations",
                columns: new[] { "ParkingSpotId", "VehicleId", "EnterDateTime" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "776f5e19-69e2-4102-bab8-5861e8accdbc", "AQAAAAEAACcQAAAAEMxkhPJqLu4PjfXNZzBoCW4pbV5eLIaXqgXy7q7R+FobduuoEQolWZl5fuvaPfGFug==", "84ba7dd8-6cf3-490f-8c5a-a3e1beeca409" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6a89db0-73c0-4523-957a-4329f5a7bf91", "AQAAAAEAACcQAAAAEF6ZbHYl5dHV+dPn1t5fPuX/iMkfr39sLt/aLlfK5FGwtJ2kKQ9g8gsjwzi1+nMlNA==", "36274256-3896-4c4c-a994-4193ca8c0d55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c44bd51-8e45-4460-8c9f-dcd2dac8671a", "AQAAAAEAACcQAAAAEPMiVw+Et3ATrsexlhca/pvI4vcUSI8STfmvPhmg8sumPjAhs46HvNo76vUh8JCrYQ==", "2641f1c1-4fef-47e2-ba65-5c3913b74b4c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpotOccupations",
                table: "ParkingSpotOccupations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ParkingSpotOccupations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpotOccupations",
                table: "ParkingSpotOccupations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25f52ed2-7029-4e35-94d1-3e487c5e536d", "AQAAAAEAACcQAAAAEB+e9xKFxbhkxXDyO1RKpoiKmC+IV3FctpYV7gIxKmwpzh42WMStwwQYCRRFZT72/w==", "c622062d-e4bb-409c-be1f-8a7a2ad3aa7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ea94f58-d706-423e-b15d-45b52bc33631", "AQAAAAEAACcQAAAAEOd7yAc0vqQKpnUhY1x0AKMa4LZHTTyWCADOsbEeDgYfP1Pqjdv6iAVCbqCk+Td10A==", "b9333df1-fcfe-49ef-9c95-2749d0709b5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc2cb7f2-e558-4861-9430-4d7edd02f7bb", "AQAAAAEAACcQAAAAECQcq7X7pQvbNo6Jmlnic+h1SVq6LlYvbvyFn9dBR1mPgM2o+/g5utfLuh+4u9z+lw==", "d1d57024-58e9-453c-8e77-41449404b613" });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpotOccupations_ParkingSpotId",
                table: "ParkingSpotOccupations",
                column: "ParkingSpotId");
        }
    }
}
