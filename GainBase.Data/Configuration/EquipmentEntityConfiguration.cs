using GainBase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GainBase.Data.Configuration
{
    public class EquipmentEntityConfiguration : IEntityTypeConfiguration<Equipment>
    {
        
        public void Configure(EntityTypeBuilder<Equipment> entity)
        {
            entity.HasData(equipments);
        }

        private readonly IEnumerable<Equipment> equipments = new Equipment[]
        {
            new Equipment { Id = 1, Name = "None" },
            new Equipment { Id = 2, Name = "Resistance Band" },
            new Equipment { Id = 3, Name = "Squat Rack" },
            new Equipment { Id = 4, Name = "Bench Press" },
            new Equipment { Id = 5, Name = "Arm Curl Machine" },
            new Equipment { Id = 6, Name = "Arm Extension Machine" },
            new Equipment { Id = 7, Name = "Rowing Machine" },
            new Equipment { Id = 8, Name = "Parallel Bars" },
            new Equipment { Id = 9, Name = "Pull-up Bar" },
            new Equipment { Id = 10, Name = "Shoulder Press Machine" },
            new Equipment { Id = 11, Name = "Lateral Raises Machine" },
            new Equipment { Id = 12, Name = "Chest Press Machine" },
            new Equipment { Id = 13, Name = "Chest Fly Machine" },
            new Equipment { Id = 14, Name = "Back Extension Machine" },
            new Equipment { Id = 15, Name = "Lat Pulldown Machine" },
            new Equipment { Id = 16, Name = "Ab Crunch Machine" },
            new Equipment { Id = 17, Name = "Leg Press Machine" },
            new Equipment { Id = 18, Name = "Leg Extension Machine" },
            new Equipment { Id = 19, Name = "Leg Curl Machine" },
            new Equipment { Id = 20, Name = "Smith Machine" },
            new Equipment { Id = 21, Name = "Cable Crossover Machine" },
            new Equipment { Id = 22, Name = "Treadmill" },
            new Equipment { Id = 23, Name = "Stationary Bike" },
            new Equipment { Id = 24, Name = "Elliptical Trainer" },
            new Equipment { Id = 25, Name = "Stair Climber" },

        };
    }
}
