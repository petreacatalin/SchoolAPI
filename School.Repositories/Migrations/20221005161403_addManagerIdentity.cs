using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Repositories.Migrations
{
    public partial class addManagerIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "113f0ebd-4122-44f7-a572-44f04a4e2acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cfd3844-e769-4c5b-8b4f-c6f40f460e23");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90df4562-ff4c-4933-8d3b-2ad1e75b060f", "f65a1e76-0eb4-484a-b7e7-4745747ba268", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d792ffda-8118-4e3f-b2dd-3a0a8e75d660", "42edb68b-44b7-4ed7-b2fc-220e6d2c327f", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4980d2c3-3336-4d0d-9538-a824b7515826", "9b1e8831-9a68-4615-ae8e-2313dbfd52de", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4980d2c3-3336-4d0d-9538-a824b7515826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90df4562-ff4c-4933-8d3b-2ad1e75b060f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d792ffda-8118-4e3f-b2dd-3a0a8e75d660");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "113f0ebd-4122-44f7-a572-44f04a4e2acb", "f42abb2e-6e17-4f73-b8e8-6f36f0d2ff45", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1cfd3844-e769-4c5b-8b4f-c6f40f460e23", "94cbf8f0-b0de-427c-a1ae-12bbffcbc8a3", "Professor", "PROFESSOR" });
        }
    }
}
