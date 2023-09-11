using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class seededtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskListNames",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "IsCompleted", "Name", "TaskListNameId" },
                values: new object[,]
                {
                    { 1, false, "Finish project A", 1 },
                    { 2, false, "Meeting with client", 1 },
                    { 3, false, "Grocery shopping", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskListNames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskListNames",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
