using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class RemovingTheNullVehicleForeinKeyInParkingSpotEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Vehicles_OccupationVehicleId",
                table: "ParkingSpots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_OccupationVehicleId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "OccupationVehicleId",
                table: "ParkingSpots");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7391976-2b08-4e1b-927c-b445f10d02ca", "AQAAAAEAACcQAAAAEKGV8E+iuukOCg5ryIjQD/vWDR531qDtl+rrafXLAmua4bbr6XCHiW7ZcSO7wzKbIg==", "32fba2f6-5085-4305-a06f-82ad55e0b5f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c83127c6-711f-47da-838e-9a85295abc74", "AQAAAAEAACcQAAAAEKhYfHOXoV47/q2DLaj+xZBS5jrfarL1oJTeh89hWfirWdUmYxyAKBXdHm8RjnEhTw==", "315a831c-7f4c-44e6-87c2-6cead3346d45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13a421dd-6bc5-448e-be4b-3cdb3efcd7e3", "AQAAAAEAACcQAAAAEBLZKyjT1LnuBTbXdIorKt1s2SYnKVovuoA7Z+oGnysNEDBlsg9CYM5E40I4FnAbNg==", "a73fba0d-4877-4543-bd78-c0794d7aaa54" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OccupationVehicleId",
                table: "ParkingSpots",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_OccupationVehicleId",
                table: "ParkingSpots",
                column: "OccupationVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Vehicles_OccupationVehicleId",
                table: "ParkingSpots",
                column: "OccupationVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
