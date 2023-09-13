using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class completedandpendingtasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompletedTasks",
                table: "TaskListNames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PendingTasks",
                table: "TaskListNames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TaskListNames",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedTasks", "PendingTasks" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "TaskListNames",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedTasks", "PendingTasks" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedTasks",
                table: "TaskListNames");

            migrationBuilder.DropColumn(
                name: "PendingTasks",
                table: "TaskListNames");
        }
    }
}
