using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteMathTasks.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Сondition",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "b5491224-4c2f-4585-b876-8a77aecef230");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d99f8dc2-5c18-4c20-a6c7-40456c85ef18", "AQAAAAEAACcQAAAAELcFSzgm/hmtCFstptgBpnHoKDw71FTbI3pyuYg4cMHT5y0FD44Z5Xm7xL7yKrA77g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "Сondition");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "0045dfcd-6860-4cb5-86c5-44701f72adc0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b199c1c7-e9ca-411e-8c76-4e047f396665", "AQAAAAEAACcQAAAAELUdmW4d9wrGOD9091V5vSFhEdHFl4eta55TK54USTnD3qjv8UnOzc8emjjBqvuD5A==" });
        }
    }
}
