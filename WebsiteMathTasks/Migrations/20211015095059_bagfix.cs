using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteMathTasks.Migrations
{
    public partial class bagfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "theme",
                table: "Tasks",
                newName: "Theme");

            migrationBuilder.RenameColumn(
                name: "tag",
                table: "Tasks",
                newName: "Tag");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "89cdb449-f8ac-41f8-beb0-1cd51974e82f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d68037cd-d3bd-4bd4-90a6-929e515108ba", "AQAAAAEAACcQAAAAEHZS+rRKNJPeesbkeYMwKmmeQ8Y+EHjDiAlcPT1rp9jxW0W630FHHYUotDXPEIrmHg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Theme",
                table: "Tasks",
                newName: "theme");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "Tasks",
                newName: "tag");

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
    }
}
