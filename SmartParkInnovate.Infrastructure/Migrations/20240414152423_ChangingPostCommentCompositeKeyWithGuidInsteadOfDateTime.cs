using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class ChangingPostCommentCompositeKeyWithGuidInsteadOfDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentGuid",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "WorkerId", "PostId", "CommentGuid" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1895e2c-613c-4bd7-b157-eca3a8cc6333", "AQAAAAEAACcQAAAAEA3dh+a+4ZSFCD+dfMjD5ec6Hu4UUfZh9mzfcr9oFNeWe2j7HW2G/99JvyrtkrQe3g==", "326478fc-ff06-460d-8a74-7f3dff504fbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd76d934-63e1-4c54-8120-5dfb4267189d", "AQAAAAEAACcQAAAAEHJbsPBnLiuLB+Vy0Rv1V/QmxRzZGHZ/99tXeyPFzheR8tGEKGAs+GNiiQaqwTEYIw==", "03cf418b-16ec-4a23-889d-b85d42db4668" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37e3ed1-63d1-4e24-ba43-61e4c501b897", "AQAAAAEAACcQAAAAEAij4nZe6LeytngK/DLX8T0qwUs4Z7k7vtgdm8gPZ+urOGAB8T+FpED9TB/FzhezSA==", "91e3feaf-4c86-4add-af0a-1fe15b9ef308" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentGuid",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "WorkerId", "PostId", "CommentDate" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a99734a3-4913-47eb-a3de-816949fac486", "AQAAAAEAACcQAAAAEKZr5auAZhJXsCtBRsNz4PSt8n7MRykmHkFxcIj9L3IWXZ8dIYd7WbgPpyq3bFhoqg==", "3fa138aa-a5fb-4acc-8d91-bd00439ed560" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27915539-4a95-4de1-a8ce-10717e8439fb", "AQAAAAEAACcQAAAAEJLgq+MrPGNBUmh56mICaJJUBvrS2DPM0PV17MP6nP7OHfvDJttOA2ggq2m4UDC3bw==", "1d65efb3-2bd4-4b25-90a7-1966a998a8bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3829ff0-19bc-42f3-8f89-edb3d25e7443", "AQAAAAEAACcQAAAAEDaIg9jPQANojQln72Q8Cpl1dH37hA6m6YWY1qedSkOuMc3rjSgP1Yj9v6cqrWlsig==", "542b7aed-9379-48dd-9185-6d5cad6cf8b4" });
        }
    }
}
