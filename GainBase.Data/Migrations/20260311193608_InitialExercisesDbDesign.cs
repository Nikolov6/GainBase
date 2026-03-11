using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialExercisesDbDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersExercises",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExercises", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_UsersExercises_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1b2c3d4-e5f6-7890-abcd-ef1234567890", 0, "9284cabb-ccfd-4eab-a01a-700b01dd522f", "seeduser@gainbase.com", true, false, null, "SEEDUSER@GAINBASE.COM", "SEEDUSER", "AQAAAAIAAYagAAAAEDzg6hZDZ8XPyB3fViwTmyuVM3yvOnDmZimZSUTKo39LIb06FNlhcm00Y9gufKlgOA==", null, false, "5ac30029-6548-4ee1-a20f-e11ab564bcdd", false, "SeedUser" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Resistance Band" },
                    { 3, "Squat Rack" },
                    { 4, "Bench Press" },
                    { 5, "Arm Curl Machine" },
                    { 6, "Arm Extension Machine" },
                    { 7, "Rowing Machine" },
                    { 8, "Parallel Bars" },
                    { 9, "Pull-up Bar" },
                    { 10, "Shoulder Press Machine" },
                    { 11, "Lateral Raises Machine" },
                    { 12, "Chest Press Machine" },
                    { 13, "Chest Fly Machine" },
                    { 14, "Back Extension Machine" },
                    { 15, "Lat Pulldown Machine" },
                    { 16, "Ab Crunch Machine" },
                    { 17, "Leg Press Machine" },
                    { 18, "Leg Extension Machine" },
                    { 19, "Leg Curl Machine" },
                    { 20, "Smith Machine" },
                    { 21, "Cable Crossover Machine" },
                    { 22, "Treadmill" },
                    { 23, "Stationary Bike" },
                    { 24, "Elliptical Trainer" },
                    { 25, "Stair Climber" }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Back" },
                    { 3, "Legs" },
                    { 4, "Shoulders" },
                    { 5, "Arms" },
                    { 6, "Core" },
                    { 7, "Full Body" },
                    { 8, "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "EquipmentId", "Instructions", "MuscleGroupId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("290ed620-d909-4753-8c16-1975c6c45ff6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A fundamental compound leg exercise using a squat rack.", 3, "Position the bar on your upper back, unrack it, lower your hips until thighs are parallel to the floor, then drive back up through your heels.", 3, "Barbell Squat", null },
                    { new Guid("9d6eb388-fcc9-4ae2-b624-bab179d4430f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A compound shoulder exercise using a shoulder press machine. The machine’s fixed path makes it more stable and beginner-friendly than free-weight overhead presses. Helps improve pressing power for other upper-body exercises.", 10, "Sit on the machine, grip the handles at shoulder height, press upward until your arms are fully extended, then lower back down slowly.", 4, "Overhead Press", null },
                    { new Guid("b8e967c6-7665-4cf6-ac73-245cbbfd8465"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A bodyweight back exercise performed on a pull-up bar.", 9, "Hang from the bar with an overhand grip, pull yourself up until your chin clears the bar, then lower yourself back down with control.", 2, "Pull-Up", null },
                    { new Guid("ba65e859-d292-4757-ac04-2e8cf7012869"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A static core exercise performed with bodyweight only.", 1, "Get into a forearm plank position with elbows under shoulders, keep your body in a straight line from head to heels, and hold the position while engaging your core. Try to stay in this position for as much as you can.", 6, "Plank", null },
                    { new Guid("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A compound chest exercise performed lying on a flat bench.", 4, "Lie on a flat bench, grip the bar slightly wider than shoulder-width, lower it to your chest, then press it back up to full arm extension.", 1, "Barbell Bench Press", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExercises_ExerciseId",
                table: "UsersExercises",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890");
        }
    }
}
