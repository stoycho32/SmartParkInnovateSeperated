using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class CreatingCorrectRelationForWorkerAndPostsLikesAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07499c3e-43ae-41f6-bd9a-ae09eb633d66", "AQAAAAEAACcQAAAAEI7gimHf57WsmLYUPpO/kPoPbIZqhr+QCRPJwcBtMWWUE1QhClAnL5tRH4xkWdvYYw==", "bfa38d94-2ddf-4536-81ba-b5438006e1c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dc173f4-dbf9-4afb-8da9-8118f6f814b2", "AQAAAAEAACcQAAAAEIrxfhW9X9de7TgpPNzUp/QHVKBYzfa93sQMJtKMB0N8oMgN4kTzQHycARwYIUXoFA==", "b5110177-f2bc-4784-80cf-c537371c1913" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fbed74c-f7ba-413c-9ead-6381950130e0", "AQAAAAEAACcQAAAAEHWYyCF0KnLKggiHvtL5yZqNitwptO58GZBJaY5s7rTaWO6ERwhOy1AJIlqjeCzm9g==", "b88e6cb0-f2fa-4eca-8d60-e328ab812be5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
