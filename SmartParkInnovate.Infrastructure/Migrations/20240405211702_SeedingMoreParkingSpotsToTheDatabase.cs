using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class SeedingMoreParkingSpotsToTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfcd64ab-5bee-4318-be96-8aed5e692e15", "AQAAAAEAACcQAAAAEI6lD8Z10qqIPltLiimhm1LDU6g1S0EuCH+bNTmJDz2K6U1NyD27qbfIw6L0k8RXkw==", "2970bb0b-240a-463d-99f1-ce52d5530038" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21aaaedc-8de1-4656-ab6f-3e5973a5bf66", "AQAAAAEAACcQAAAAECRcHcZ/DMGOihKXkvKMw2DL8KIrCp7bzvSI3lqP/KStmxdWM4imniItpIfH1yZDyQ==", "d9d370f8-18b5-4e12-a77f-71008345f930" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94a6b98d-e4e0-43ec-affb-ebf1e6b5cda7", "AQAAAAEAACcQAAAAELl4HQWWMz6kZRuyZHqFROlA8HSq/BrPZ3Gha03iLqEH8Rqz9uVRqk+xfCyuzysgHQ==", "7761e4b2-ef3e-468b-9ce0-f627eba52c75" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "IsEnabled", "IsOccupied" },
                values: new object[,]
                {
                    { 4, true, false },
                    { 5, true, false },
                    { 6, true, false },
                    { 7, true, false },
                    { 8, true, false },
                    { 9, true, false },
                    { 10, true, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "669ead8c-a439-4978-bd5d-86a6bc539b72", "AQAAAAEAACcQAAAAEJRfOlhiWV2My0HXw4x+4Fj9TwMhMtqBTSVtTP2Pm1lnPbf5UN9RkslFievvvWg3YQ==", "5d1c1fc9-c782-4511-a03b-ca48092fcd86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9454d2fe-2945-40e1-87e4-8ea8d39ef6df", "AQAAAAEAACcQAAAAECMCWw8KKTzv2XOvrqAIttEJWL2CveOqvBg63cmn1pbqZOvWxdyNsKMsK4/o7/+lwQ==", "a42a579f-de1a-4aec-8038-29d9156eb856" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "558e5469-8363-4d16-b860-c27059cdf421", "AQAAAAEAACcQAAAAEGBuf7/K6mNRUesmbhIiwXkvfKIus5Oqw4SsPhWwOnVRH+d+KPK+PxAUtQjDFoHyYw==", "37797c3c-6f24-40fe-8652-9951c952500f" });
        }
    }
}
