using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteMathTasks.Migrations
{
    public partial class datatime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataTime",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "cc74292a-a80a-491c-aa96-ac413ae7c3b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3edfbe0c-1ca8-4d7d-ab78-68991902abea", "AQAAAAEAACcQAAAAEK8/108RxfqYLuYqVFFGVKDY1x8ZfM1WbyiuUyuui1j1pLZlWh7qka/I4vQpvHUvtA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTime",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "c6eb3600-c4a1-433c-befb-3cfbc4c50959");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6a1fe83-dc46-41e4-b9fc-1b170e2412c8", "AQAAAAEAACcQAAAAEEn2Naka2nw/L6ZYtQNzJ5Roz58InNXfOuiGTjfZHyOSFtzNR+6/04P6TknzY82hsw==" });
        }
    }
}
