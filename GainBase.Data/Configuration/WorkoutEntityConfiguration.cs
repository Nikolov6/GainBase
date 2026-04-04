using GainBase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> entity)
        {
            entity
                .HasOne(w => w.Creator)
                .WithMany()
                .HasForeignKey(w => w.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}