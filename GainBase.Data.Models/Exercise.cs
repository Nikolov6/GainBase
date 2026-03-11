using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Data.Models
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ExerciseDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public int MuscleGroupId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        [MaxLength(ExerciseInstructionsMaxLength)]
        public string Instructions { get; set; } = null!;

        [Required]
        public string CreatorId { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(MuscleGroupId))]
        public virtual MuscleGroup MuscleGroup { get; set; } = null!;

        [ForeignKey(nameof(EquipmentId))]
        public virtual Equipment Equipment { get; set; } = null!;

        [ForeignKey(nameof(CreatorId))]
        public virtual IdentityUser Creator { get; set; } = null!;

        public virtual ICollection<UserExercise> UserExercises { get; set; } = new HashSet<UserExercise>();
    }
}
