using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class ChangingAdminEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4f3c6cd-100b-41db-88dd-8e88de9e1326", "AQAAAAEAACcQAAAAEC7kW6jQkfy3oePXl8p4z6jb5D1Ow9++kE3YfVtaOr4iyWRSLDTKTc6VEUaRUsGmYA==", "5d0b76a4-41bd-4be2-9ef4-f3e26dde743a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc964cf1-7d1b-451c-ae9e-614959d8f3b7", "AQAAAAEAACcQAAAAEF5RsQ0hCYlzRZPoejO+aL+gMBcczR8Kq/JQQ0tabDD1UUE8F2OhbSBNHbS25PVTjg==", "334b9188-04f5-4bce-93ae-344bd58e92d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f6a11c74-9d68-4156-b600-06d17264a50e", "admin@mail.com", "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEM50oF/kLinT0S2QzHdK0JM8lRVeXzgjFW+L1WpJuQN5ujyYNwowvGad7nSEiQu79Q==", "924b0d62-9d2f-4fcb-b1f7-3bbe709a2bee", "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ff814433-4aac-4ce5-bb36-d52963cb85ff", "test3@mail.com", "test3@mail.com", "test3@mail.com", "AQAAAAEAACcQAAAAEPfnoRBgv+h4jQXAhhKvKEUqWtaYBW1O0ggngc/smh/1IyOr0SlKj1qKhs+17f7MjQ==", "033b52e2-669d-4d25-a2bc-e7e286f2956f", "test3@mail.com" });
        }
    }
}
