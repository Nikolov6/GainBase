using GainBase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class GymSessionEntityConfiguration : IEntityTypeConfiguration<GymSession>
    {
        public void Configure(EntityTypeBuilder<GymSession> entity)
        {
            entity
                .HasOne(gs => gs.Workout)
                .WithMany(w => w.GymSessions)
                .HasForeignKey(gs => gs.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(gs => gs.User)
                .WithMany()
                .HasForeignKey(gs => gs.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasMany(gs => gs.ExerciseLogs)
                .WithOne(el => el.GymSession)
                .HasForeignKey(el => el.GymSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}