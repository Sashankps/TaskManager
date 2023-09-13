using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsCompleted",
                value: true);

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "IsCompleted", "Name", "TaskListNameId" },
                values: new object[,]
                {
                    { 4, true, "Write report", 1 },
                    { 5, true, "Exercise", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsCompleted",
                value: false);
        }
    }
}
