using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExerciseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "597a3a8b-0e0d-4d45-9f0c-dd561c7b59d7", "AQAAAAIAAYagAAAAENG1culb9g5JbBbFkOyKwsKYZr7Fzg64rGpiXBNgwyfIPtH1eH1lzjW01NjBED/rXQ==", "d0bb65b5-ae2c-41fe-80e2-4e71e9803a8d" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("290ed620-d909-4753-8c16-1975c6c45ff6"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A fundamental compound leg exercise. It is widely considered the premier exercise for building lower-body size and strength, primarily targeting the quadriceps and glutes while engaging the core and back for stability.", "Position yourself under a barbell set on a squat rack so the bar rests across your upper back on the trapezius muscles. Grip the bar with both hands slightly wider than shoulder width and pull your shoulder blades together to create a stable shelf for the bar. Lift the bar out of the rack by straightening your legs and step back until you have enough space to perform the movement. Stand with your feet approximately shoulder-width apart with your toes slightly pointed outward. Keep your chest up, back neutral, and core braced. Begin the movement by pushing your hips back and bending your knees at the same time, lowering your body in a controlled manner. Continue descending until your thighs reach at least parallel with the floor or slightly lower while keeping your heels flat on the ground. Maintain your knees tracking in the same direction as your toes and keep the bar balanced over the middle of your feet. Reverse the movement by driving through your heels and extending your hips and knees at the same time. Continue rising until you return to a fully upright standing position with your hips and knees extended. After completing the desired number of repetitions, step forward carefully and place the bar back onto the rack hooks." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A compound shoulder exercise. The machine’s fixed path makes it more stable and beginner-friendly than free-weight overhead presses. Helps improve pressing power for other upper-body exercises.", "Sit on the shoulder press machine and adjust the seat height so the handles are positioned roughly at shoulder level when you grasp them. Place your back firmly against the backrest and keep your feet flat on the floor. Grip the handles with both hands and position your elbows slightly below or in line with your shoulders. Brace your core and keep your back in contact with the backrest throughout the movement. Press the handles upward by extending your arms until they are nearly fully straight above you without locking your elbows aggressively. Pause briefly at the top while maintaining control of the weight. Slowly lower the handles back down toward shoulder level by bending your elbows in a controlled manner. Continue lowering until the handles return to the starting position near your shoulders. Repeat the movement for the desired number of repetitions while maintaining steady and controlled motion." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "It primarily targets the back muscles (lats) and biceps providing immense strength and posture benefits.", "Stand beneath a pull-up bar and grasp it with a pronated grip slightly wider than shoulder width. Hang from the bar with your arms fully extended and your body straight, keeping your legs slightly bent or crossed if needed to avoid touching the ground. Engage your core and pull your shoulder blades down and back to stabilize your shoulders. Begin the movement by pulling your body upward, driving your elbows down toward your sides while keeping your torso relatively upright. Continue pulling until your chin rises above the bar. Pause briefly at the top while maintaining control, then slowly lower your body by extending your arms until you return to the starting position with your arms fully extended. Repeat for the desired number of repetitions while maintaining controlled movement throughout." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ba65e859-d292-4757-ac04-2e8cf7012869"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A static core exercise performed with bodyweight only. Planks help build endurance, enhance balance, and prevent injuries by strengthening the muscles that support the spine. They also promote better posture and can improve athletic performance.", "Start by positioning yourself face down on the floor and place your forearms on the ground with your elbows directly under your shoulders. Extend your legs behind you and place your toes on the floor so your body is supported by your forearms and toes. Lift your body off the ground and align your head, shoulders, hips, and legs in a straight line. Keep your core engaged and your glutes slightly tightened while maintaining a neutral spine. Avoid letting your hips drop toward the floor or rise too high. Keep your neck in a neutral position by looking down toward the floor. Hold this position for the desired amount of time while maintaining steady breathing and full-body tension. When finished, gently lower your knees to the floor to exit the position." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A compound, upper-body strength exercise. It primarily targets the pectoralis major (chest), while engaging the anterior deltoids (shoulders) and triceps brachii (back of arms) for maximal muscle growth and strength.", "Lie flat on a bench with your eyes positioned roughly under the barbell. Place your feet flat on the floor and keep them planted for stability. Grip the bar with a pronated grip slightly wider than shoulder width, wrapping your thumbs around the bar. Retract your shoulder blades and keep them pressed into the bench while maintaining a small natural arch in your lower back. Lift the barbell out of the rack by straightening your arms and move it horizontally until it is positioned above your shoulders. Lower the bar slowly and under control toward your chest while keeping your elbows at an angle roughly between 45 and 75 degrees from your torso. Continue lowering until the bar lightly touches the middle or lower part of your chest. Press the bar upward by extending your elbows while maintaining tension through your chest, shoulders, and triceps, guiding the bar slightly back toward the starting position above your shoulders. Continue pressing until your arms are fully extended. Repeat for the desired number of repetitions, then carefully move the bar back toward the rack and secure it onto the hooks." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9284cabb-ccfd-4eab-a01a-700b01dd522f", "AQAAAAIAAYagAAAAEDzg6hZDZ8XPyB3fViwTmyuVM3yvOnDmZimZSUTKo39LIb06FNlhcm00Y9gufKlgOA==", "5ac30029-6548-4ee1-a20f-e11ab564bcdd" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("290ed620-d909-4753-8c16-1975c6c45ff6"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A fundamental compound leg exercise using a squat rack.", "Position the bar on your upper back, unrack it, lower your hips until thighs are parallel to the floor, then drive back up through your heels." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A compound shoulder exercise using a shoulder press machine. The machine’s fixed path makes it more stable and beginner-friendly than free-weight overhead presses. Helps improve pressing power for other upper-body exercises.", "Sit on the machine, grip the handles at shoulder height, press upward until your arms are fully extended, then lower back down slowly." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A bodyweight back exercise performed on a pull-up bar.", "Hang from the bar with an overhand grip, pull yourself up until your chin clears the bar, then lower yourself back down with control." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ba65e859-d292-4757-ac04-2e8cf7012869"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A static core exercise performed with bodyweight only.", "Get into a forearm plank position with elbows under shoulders, keep your body in a straight line from head to heels, and hold the position while engaging your core. Try to stay in this position for as much as you can." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"),
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "A compound chest exercise performed lying on a flat bench.", "Lie on a flat bench, grip the bar slightly wider than shoulder-width, lower it to your chest, then press it back up to full arm extension." });
        }
    }
}
