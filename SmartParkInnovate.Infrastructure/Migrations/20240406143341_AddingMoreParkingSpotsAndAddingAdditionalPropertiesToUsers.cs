using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class AddingMoreParkingSpotsAndAddingAdditionalPropertiesToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32a32bda-d22b-4308-bc37-3c82c5dcc8c2", "AQAAAAEAACcQAAAAEMoZPXuIu5fJgWjtwRv6QBQbo+cVTbqw5AX15MJrKH85qNtTrpLlJo2fMhjTZZAa6g==", "5afc146f-81a7-4808-aee4-c1f01af1fa11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32fcdfda-676f-4fba-b6df-e8e714404543", "AQAAAAEAACcQAAAAEJR1wQugqxjBzE4noVN9dVVXYwnGz073KIUc52NF754vQJggI1ZZc8yJxi/dSkCwgA==", "6a56f76b-c2f9-4f7f-b45f-8aa7bcf2789c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff814433-4aac-4ce5-bb36-d52963cb85ff", "AQAAAAEAACcQAAAAEPfnoRBgv+h4jQXAhhKvKEUqWtaYBW1O0ggngc/smh/1IyOr0SlKj1qKhs+17f7MjQ==", "033b52e2-669d-4d25-a2bc-e7e286f2956f" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "IsEnabled", "IsOccupied" },
                values: new object[,]
                {
                    { 1, true, false },
                    { 2, true, false },
                    { 3, true, false },
                    { 4, true, false },
                    { 5, true, false },
                    { 6, true, false },
                    { 7, true, false },
                    { 8, true, false },
                    { 9, true, false },
                    { 10, true, false },
                    { 11, true, false },
                    { 12, true, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a211a46-20cd-4be5-befa-ad618bdc8238", "AQAAAAEAACcQAAAAELCcuufgia5ESO2paWXoNZI12KiPQZ4gv4roP2qERScu4NxwrZhMvZKSGATCqjF6xw==", "bf41b796-faae-498e-8c6e-435533049f58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5a72879-6360-4090-9815-14b2f8af513a", "AQAAAAEAACcQAAAAEJKywZtXn3khhCnG/WcAGkJtDC1QEMKFZsX1hP/vxAUBvzFuBGwninQVksys41ivhw==", "5208f7ca-50d5-440d-b2cd-9b7fafea531c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18424548-7ad5-462c-ae77-743cd9e99ba3", "AQAAAAEAACcQAAAAEEQsxlYDIwwNRh5bSd/u6i8Op+L0TVsS8ajkm31b+Ge1tw+p/aOmeTlifgQnXir+QA==", "e37cf3e5-d961-4c4f-9dfb-675861438b52" });
        }
    }
}
