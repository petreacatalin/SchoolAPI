using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Repositories.Migrations
{
    public partial class firstmigsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f222a282-f836-407a-9dbb-2dc85f0e558a", "cdd07588-d25e-4db6-abdf-c49951fee961", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6eb3d394-c172-4aa3-9e04-7f0e75b474a6", "406301a2-5d10-4dc3-bd34-bbe40718f215", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "822664a2-60c5-4812-80b1-5654d6ca48ee", "0876516d-f1a0-4508-8851-654c479f1a8e", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eb3d394-c172-4aa3-9e04-7f0e75b474a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "822664a2-60c5-4812-80b1-5654d6ca48ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f222a282-f836-407a-9dbb-2dc85f0e558a");

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
    }
}
