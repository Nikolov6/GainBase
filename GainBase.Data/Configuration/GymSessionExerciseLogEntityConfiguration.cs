using GainBase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class GymSessionExerciseLogEntityConfiguration : IEntityTypeConfiguration<GymSessionExerciseLog>
    {
        public void Configure(EntityTypeBuilder<GymSessionExerciseLog> entity)
        {
            entity
                .HasOne(el => el.Exercise)
                .WithMany(e => e.GymSessionExerciseLogs)
                .HasForeignKey(el => el.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(el => el.GymSession)
                .WithMany(gs => gs.ExerciseLogs)
                .HasForeignKey(el => el.GymSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}