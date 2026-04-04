using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExecutionOrderToWorkoutExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExecutionOrder",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "108d2dcf-036f-4fef-9f99-00a00ffae286", "AQAAAAIAAYagAAAAEMHn1jVn2j1CF7qdF0WbEKA26GNuD2xDvXHg8TEZDivaE94zqJ3DSMUl+HtnAXMXZQ==", "8e60e9f5-2b9e-4f28-a5b9-2907bd8ce5c6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionOrder",
                table: "WorkoutExercises");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "138a6a20-6bc1-4432-87d4-482e6e21f473", "AQAAAAIAAYagAAAAEFMD0LhZuwR+BgrVM43EDFWnLKkin+6EvqxOXyGx+XZXFpJf6U+S6Qh+v1rR09v5Cg==", "daa96b29-e8b9-4a41-8c22-5ac4a797a5b4" });
        }
    }
}
