using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSys_SURE.Migrations
{
    /// <inheritdoc />
    public partial class sedding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed", "AI" },
                    { 2, "Mohamed", "SE" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "cairo", 22, 1, "Ammar" },
                    { 2, "Mansoura", 24, 1, "Mai" },
                    { 3, "Alex", 20, 2, "Hazem" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
