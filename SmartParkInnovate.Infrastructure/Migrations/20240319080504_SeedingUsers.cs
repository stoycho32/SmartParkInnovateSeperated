using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class SeedingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "25f52ed2-7029-4e35-94d1-3e487c5e536d", "test2@mail.com", false, false, null, "test2@mail.com", "test2@mail.com", "AQAAAAEAACcQAAAAEB+e9xKFxbhkxXDyO1RKpoiKmC+IV3FctpYV7gIxKmwpzh42WMStwwQYCRRFZT72/w==", null, false, "c622062d-e4bb-409c-be1f-8a7a2ad3aa7c", false, "test2@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cc644110-5a86-4e9f-9664-fde76465c618", 0, "6ea94f58-d706-423e-b15d-45b52bc33631", "test3@mail.com", false, false, null, "test3@mail.com", "test3@mail.com", "AQAAAAEAACcQAAAAEOd7yAc0vqQKpnUhY1x0AKMa4LZHTTyWCADOsbEeDgYfP1Pqjdv6iAVCbqCk+Td10A==", null, false, "b9333df1-fcfe-49ef-9c95-2749d0709b5b", false, "test3@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 0, "dc2cb7f2-e558-4861-9430-4d7edd02f7bb", "test1@mail.com", false, false, null, "test1@mail.com", "test1@mail.com", "AQAAAAEAACcQAAAAECQcq7X7pQvbNo6Jmlnic+h1SVq6LlYvbvyFn9dBR1mPgM2o+/g5utfLuh+4u9z+lw==", null, false, "d1d57024-58e9-453c-8e77-41449404b613", false, "test1@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
