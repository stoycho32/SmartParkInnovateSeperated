using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    public partial class ChangingPostLikesAndPostCommentsToBeAProperMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "WorkerId", "PostId", "CommentDate" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

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
    }
}
