using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Data.Models
{
    public class GymSession
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid WorkoutId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        [Range(GymSessionDurationMinMinutes, GymSessionDurationMaxMinutes)]
        public int DurationMinutes { get; set; }

        [MaxLength(GymSessionNoteMaxLength)]
        public string? Note { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<GymSessionExerciseLog> ExerciseLogs { get; set; }
            = new HashSet<GymSessionExerciseLog>();
    }
}