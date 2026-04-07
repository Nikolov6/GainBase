using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreExercisesForPagination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "EquipmentId", "Instructions", "IsDeleted", "MuscleGroupId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1001"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A compound upper-body movement emphasizing the upper chest while also training the front deltoids and triceps.", 4, "Set an adjustable bench to a moderate incline and sit with a dumbbell in each hand resting on your thighs. Lie back while guiding the dumbbells to chest level, keep your feet planted, and retract your shoulder blades to create a stable pressing position. Press the dumbbells upward in a controlled arc until your elbows are nearly extended, then lower them slowly to the starting position while maintaining tension through the chest and shoulders. Keep your wrists neutral, avoid bouncing at the bottom, and repeat each repetition with the same range of motion and steady tempo.", false, 1, "Incline Dumbbell Press", null },
                    { new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1002"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A machine-based vertical pulling exercise that develops the lats, upper back, and biceps.", 15, "Sit at the lat pulldown station and secure your thighs under the pad so your lower body remains stable. Grip the bar slightly wider than shoulder width, brace your core, and pull the bar toward your upper chest by driving your elbows down and back while keeping your torso mostly upright. Pause briefly at the bottom to contract your back muscles, then return the bar upward with control until your arms are extended without letting the weight stack slam. Maintain consistent posture, avoid excessive body swing, and perform each repetition with smooth, deliberate movement.", false, 2, "Lat Pulldown", null },
                    { new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1003"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A hip-hinge compound exercise targeting hamstrings, glutes, and lower-back stabilizers.", 20, "Stand tall with the barbell in front of your thighs, hands at about shoulder width, and knees slightly bent. Initiate the movement by pushing your hips backward while keeping your chest lifted and spine neutral, allowing the bar to travel down close to your legs until you feel a deep stretch in your hamstrings. Reverse the motion by driving your hips forward and squeezing your glutes to return to standing without leaning back excessively at the top. Keep the bar path close, move in a controlled manner, and avoid rounding your lower back throughout the set.", false, 3, "Romanian Deadlift", null },
                    { new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1004"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "A horizontal pulling exercise that strengthens the mid-back, rear delts, and biceps.", 21, "Sit at the cable row station with knees slightly bent and your torso upright, then grasp the handle with a neutral grip. Start with arms extended and shoulders stable, pull the handle toward your lower ribcage by driving elbows back and squeezing your shoulder blades together at peak contraction. Hold briefly, then extend your arms forward slowly to return to the start position while keeping tension on the back muscles. Avoid jerking your torso, keep your core braced, and repeat each rep with controlled form and full range.", false, 2, "Seated Cable Row", null },
                    { new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1005"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "a1b2c3d4-e5f6-7890-abcd-ef1234567890", "An isolation movement for building triceps strength and elbow extension control.", 21, "Attach a straight or rope handle to a high cable pulley and stand facing the machine with a stable stance. Keep your elbows tucked close to your torso and begin with forearms bent, then press the handle downward by extending your elbows until your arms are straight without locking aggressively. Pause briefly to contract the triceps, then allow the handle to rise back up under control while keeping your upper arms fixed in place. Maintain a neutral wrist position, avoid using body momentum, and repeat with smooth and consistent execution.", false, 5, "Cable Triceps Pushdown", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("7e8d2d4a-1d0d-4b17-9f5d-0e7c9d7b1005"));
        }
    }
}
