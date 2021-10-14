using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteMathTasks.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "138338c7-278c-4911-a212-7feb50f99951");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44d1d7cf-28f0-4a7e-9f62-765098dc0c7f", "AQAAAAEAACcQAAAAEPfe/Kr1ykywG6z1FWj62gphMNJVuxMAz8lZL/spckMxRfXiXPThe7x0ePpxDP+O/g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "43a91a81-baf2-4985-843e-e1eb8db467a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5cfb99ba-0294-4d31-b081-b692e62e1327", "AQAAAAEAACcQAAAAEAxJfs7fR7poQh1J3nDFmMraoixs2LfrKD05HFLucsw2MGAq272n3FlQ3dRWHJIVbg==" });
        }
    }
}
