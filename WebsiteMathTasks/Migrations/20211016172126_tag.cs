using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteMathTasks.Migrations
{
    public partial class tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "efbe8a82-8f5c-46f3-baf7-a8d1c46eb627");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f27b8ec9-a260-4a82-8197-de7d7557ca34", "AQAAAAEAACcQAAAAEC5kZQLhIXtoVqi0fxj7/hSrgKzPXTfAJNFvFt/0absA/EpNgSZvxTPKwvoI7wxBHw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tags");

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
    }
}
