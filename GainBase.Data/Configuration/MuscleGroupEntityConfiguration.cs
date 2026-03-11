using GainBase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class MuscleGroupEntityConfiguration : IEntityTypeConfiguration<MuscleGroup>
    {
        public void Configure(EntityTypeBuilder<MuscleGroup> entity)
        {
            entity.HasData(muscleGroups);
        }

        private readonly IEnumerable<MuscleGroup> muscleGroups = new MuscleGroup[]
        {
            new MuscleGroup { Id = 1, Name = "Chest" },
            new MuscleGroup { Id = 2, Name = "Back" },
            new MuscleGroup { Id = 3, Name = "Legs" },
            new MuscleGroup { Id = 4, Name = "Shoulders" },
            new MuscleGroup { Id = 5, Name = "Arms" },
            new MuscleGroup { Id = 6, Name = "Core" },
            new MuscleGroup { Id = 7, Name = "Full Body" },
            new MuscleGroup { Id = 8, Name = "Cardio" },
        };
    }
}
