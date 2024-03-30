using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class ChangingTheCommentsAndLikesToBeProperMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostLikes_WorkerId",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_WorkerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes",
                columns: new[] { "WorkerId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "WorkerId", "PostId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5ce53b0-c7b7-43fe-9ce3-262c680f660f", "AQAAAAEAACcQAAAAEKL+N3b/Xnq81qK1Y/t6dTAa5GkJrzb24PGk6o65e5D1foEhKJl5xBlw3xR8Z/+9yA==", "62a565c0-0133-4831-8d34-6afc91f18eb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc644110-5a86-4e9f-9664-fde76465c618",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df6e5a8a-0402-452c-ab8e-51bd79814b91", "AQAAAAEAACcQAAAAENau06EHotLd8VInshBoZ3THx7JY+bcBBFBsfe93sFM132D/dA741MQIUAcKgoB+Fg==", "c374241b-3948-4b54-b100-8d6b8a9e7dc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1b13622-850b-4f7f-b9fc-b9534c690752", "AQAAAAEAACcQAAAAEH7gfvgLTCDO4St11xTw5zC+LaV88W5xw1/rgfcWE1E6c56FZiJNB18VClECoa/ylA==", "5d281853-bbcb-4ae0-9430-3a68efcc4bfb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostLikes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_WorkerId",
                table: "PostLikes",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WorkerId",
                table: "Comments",
                column: "WorkerId");
        }
    }
}
