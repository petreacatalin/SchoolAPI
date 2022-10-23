using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Repositories.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "5f0a4df7-9620-4bfb-907f-b9d35d1412a9", "8a22fbab-022d-4f85-a75c-3783b69c97d2", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18765729-1c95-4477-8053-77eb7102da15", "bdedc2a5-1f54-4f25-8b35-a11586428efd", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "711d38b6-49a4-4fe9-a699-fc005881b657", "3051e08a-a132-4c63-a8e0-6c78d0f2b9c6", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18765729-1c95-4477-8053-77eb7102da15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f0a4df7-9620-4bfb-907f-b9d35d1412a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711d38b6-49a4-4fe9-a699-fc005881b657");

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
    }
}
