using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class ImplementingIDeletableForPostAndComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6a11c74-9d68-4156-b600-06d17264a50e", "AQAAAAEAACcQAAAAEM50oF/kLinT0S2QzHdK0JM8lRVeXzgjFW+L1WpJuQN5ujyYNwowvGad7nSEiQu79Q==", "924b0d62-9d2f-4fcb-b1f7-3bbe709a2bee" });
        }
    }
}
