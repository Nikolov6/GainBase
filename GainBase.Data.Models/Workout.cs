using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Data.Models
{
    public class Workout
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(WorkoutNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(WorkoutDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public string CreatorId { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public virtual IdentityUser Creator { get; set; } = null!;

        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new HashSet<WorkoutExercise>();
        public virtual ICollection<GymSession> GymSessions { get; set; } = new HashSet<GymSession>();
    }
}