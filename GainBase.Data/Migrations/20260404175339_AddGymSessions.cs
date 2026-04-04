using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGymSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymSessions_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GymSessionExerciseLogs",
                columns: table => new
                {
                    GymSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseOrder = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSessionExerciseLogs", x => new { x.GymSessionId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_GymSessionExerciseLogs_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymSessionExerciseLogs_GymSessions_GymSessionId",
                        column: x => x.GymSessionId,
                        principalTable: "GymSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e33fb333-55ab-40e1-aeb7-8249e7913af8", "AQAAAAIAAYagAAAAEBLhv0+RzV1RtBYdiOHAP2Drc4/PYIlVjegUTro7wPL5UqmutJ4tZ7RNaWYxJZ8qFA==", "ace19f2d-c45a-48a1-898a-2483cd0d2b02" });

            migrationBuilder.CreateIndex(
                name: "IX_GymSessionExerciseLogs_ExerciseId",
                table: "GymSessionExerciseLogs",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_GymSessions_UserId",
                table: "GymSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GymSessions_WorkoutId",
                table: "GymSessions",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymSessionExerciseLogs");

            migrationBuilder.DropTable(
                name: "GymSessions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "108d2dcf-036f-4fef-9f99-00a00ffae286", "AQAAAAIAAYagAAAAEMHn1jVn2j1CF7qdF0WbEKA26GNuD2xDvXHg8TEZDivaE94zqJ3DSMUl+HtnAXMXZQ==", "8e60e9f5-2b9e-4f28-a5b9-2907bd8ce5c6" });
        }
    }
}
