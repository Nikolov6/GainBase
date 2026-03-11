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
                Description = "A compound chest exercise performed lying on a flat bench.",
                MuscleGroupId = 1,
                EquipmentId = 4,
                Instructions = "Lie on a flat bench, grip the bar slightly wider than shoulder-width, lower it to your chest, then press it back up to full arm extension.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("290ed620-d909-4753-8c16-1975c6c45ff6"),
                Name = "Barbell Squat",
                Description = "A fundamental compound leg exercise using a squat rack.",
                MuscleGroupId = 3,
                EquipmentId = 3,
                Instructions = "Position the bar on your upper back, unrack it, lower your hips until thighs are parallel to the floor, then drive back up through your heels.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                Name = "Pull-Up",
                Description = "A bodyweight back exercise performed on a pull-up bar.",
                MuscleGroupId = 2,
                EquipmentId = 9,
                Instructions = "Hang from the bar with an overhand grip, pull yourself up until your chin clears the bar, then lower yourself back down with control.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                Name = "Overhead Press",
                Description = "A compound shoulder exercise using a shoulder press machine. The machine’s fixed path makes it more stable and beginner-friendly than free-weight overhead presses. Helps improve pressing power for other upper-body exercises.",
                MuscleGroupId = 4,
                EquipmentId = 10,
                Instructions = "Sit on the machine, grip the handles at shoulder height, press upward until your arms are fully extended, then lower back down slowly.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new Exercise
            {
                Id = Guid.Parse("ba65e859-d292-4757-ac04-2e8cf7012869"),
                Name = "Plank",
                Description = "A static core exercise performed with bodyweight only.",
                MuscleGroupId = 6,
                EquipmentId = 1,
                Instructions = "Get into a forearm plank position with elbows under shoulders, keep your body in a straight line from head to heels, and hold the position while engaging your core. Try to stay in this position for as much as you can.",
                CreatorId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            },
        };
    }
}