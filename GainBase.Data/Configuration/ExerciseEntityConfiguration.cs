using GainBase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity
                .HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(exercises);
        }

        private readonly IEnumerable<Exercise> exercises = new Exercise[]
        {
            new Exercise
            {
                Id = Guid.Parse("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"),
                Name = "Barbell Bench Press",
                Description = "A compound, upper-body strength exercise. It primarily targets the pectoralis major (chest), while engaging the anterior deltoids (shoulders) and triceps brachii (back of arms) for maximal muscle growth and strength.",
                MuscleGroupId = 1,
                EquipmentId = 4,
                Instructions = "Lie flat on a bench with your eyes positioned roughly under the barbell. Place your feet flat on the floor and keep them planted for stability. Grip the bar with a pronated grip slightly wider than shoulder width, wrapping your thumbs around the bar. Retract your shoulder blades and keep them pressed into the bench while maintaining a small natural arch in your lower back. Lift the barbell out of the rack by straightening your arms and move it horizontally until it is positioned above your shoulders. Lower the bar slowly and under control toward your chest while keeping your elbows at an angle roughly between 45 and 75 degrees from your torso. Continue lowering until the bar lightly touches the middle or lower part of your chest. Press the bar upward by extending your elbows while maintaining tension through your chest, shoulders, and triceps, guiding the bar slightly back toward the starting position above your shoulders. Continue pressing until your arms are fully extended. Repeat for the desired number of repetitions, then carefully move the bar back toward the rack and secure it onto the hooks.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("290ed620-d909-4753-8c16-1975c6c45ff6"),
                Name = "Barbell Squat",
                Description = "A fundamental compound leg exercise. It is widely considered the premier exercise for building lower-body size and strength, primarily targeting the quadriceps and glutes while engaging the core and back for stability.",
                MuscleGroupId = 3,
                EquipmentId = 3,
                Instructions = "Position yourself under a barbell set on a squat rack so the bar rests across your upper back on the trapezius muscles. Grip the bar with both hands slightly wider than shoulder width and pull your shoulder blades together to create a stable shelf for the bar. Lift the bar out of the rack by straightening your legs and step back until you have enough space to perform the movement. Stand with your feet approximately shoulder-width apart with your toes slightly pointed outward. Keep your chest up, back neutral, and core braced. Begin the movement by pushing your hips back and bending your knees at the same time, lowering your body in a controlled manner. Continue descending until your thighs reach at least parallel with the floor or slightly lower while keeping your heels flat on the ground. Maintain your knees tracking in the same direction as your toes and keep the bar balanced over the middle of your feet. Reverse the movement by driving through your heels and extending your hips and knees at the same time. Continue rising until you return to a fully upright standing position with your hips and knees extended. After completing the desired number of repetitions, step forward carefully and place the bar back onto the rack hooks.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                Name = "Pull-Up",
                Description = "It primarily targets the back muscles (lats) and biceps providing immense strength and posture benefits.",
                MuscleGroupId = 2,
                EquipmentId = 9,
                Instructions = "Stand beneath a pull-up bar and grasp it with a pronated grip slightly wider than shoulder width. Hang from the bar with your arms fully extended and your body straight, keeping your legs slightly bent or crossed if needed to avoid touching the ground. Engage your core and pull your shoulder blades down and back to stabilize your shoulders. Begin the movement by pulling your body upward, driving your elbows down toward your sides while keeping your torso relatively upright. Continue pulling until your chin rises above the bar. Pause briefly at the top while maintaining control, then slowly lower your body by extending your arms until you return to the starting position with your arms fully extended. Repeat for the desired number of repetitions while maintaining controlled movement throughout.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                Name = "Overhead Press",
                Description = "A compound shoulder exercise. The machine’s fixed path makes it more stable and beginner-friendly than free-weight overhead presses. Helps improve pressing power for other upper-body exercises.",
                MuscleGroupId = 4,
                EquipmentId = 10,
                Instructions = "Sit on the shoulder press machine and adjust the seat height so the handles are positioned roughly at shoulder level when you grasp them. Place your back firmly against the backrest and keep your feet flat on the floor. Grip the handles with both hands and position your elbows slightly below or in line with your shoulders. Brace your core and keep your back in contact with the backrest throughout the movement. Press the handles upward by extending your arms until they are nearly fully straight above you without locking your elbows aggressively. Pause briefly at the top while maintaining control of the weight. Slowly lower the handles back down toward shoulder level by bending your elbows in a controlled manner. Continue lowering until the handles return to the starting position near your shoulders. Repeat the movement for the desired number of repetitions while maintaining steady and controlled motion.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("ba65e859-d292-4757-ac04-2e8cf7012869"),
                Name = "Plank",
                Description = "A static core exercise performed with bodyweight only. Planks help build endurance, enhance balance, and prevent injuries by strengthening the muscles that support the spine. They also promote better posture and can improve athletic performance.",
                MuscleGroupId = 6,
                EquipmentId = 1,
                Instructions = "Start by positioning yourself face down on the floor and place your forearms on the ground with your elbows directly under your shoulders. Extend your legs behind you and place your toes on the floor so your body is supported by your forearms and toes. Lift your body off the ground and align your head, shoulders, hips, and legs in a straight line. Keep your core engaged and your glutes slightly tightened while maintaining a neutral spine. Avoid letting your hips drop toward the floor or rise too high. Keep your neck in a neutral position by looking down toward the floor. Hold this position for the desired amount of time while maintaining steady breathing and full-body tension. When finished, gently lower your knees to the floor to exit the position.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
        };
    }
}