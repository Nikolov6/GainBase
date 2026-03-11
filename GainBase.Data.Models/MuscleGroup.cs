using System.ComponentModel.DataAnnotations;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Data.Models
{
    public class MuscleGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MuscleGroupNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
    }
}
