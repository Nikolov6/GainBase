using System.ComponentModel.DataAnnotations;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Web.ViewModels.GymSession
{
    public class GymSessionCreateFormModel
    {
        [Required]
        public Guid WorkoutId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; } = DateTime.Today;

        [Required]
        [Range(GymSessionDurationMinMinutes, GymSessionDurationMaxMinutes)]
        [Display(Name = "Duration (minutes)")]
        public int DurationMinutes { get; set; }

        [MaxLength(GymSessionNoteMaxLength)]
        public string? Note { get; set; }

        public string WorkoutName { get; set; } = null!;

        public List<GymSessionExerciseLogInputModel> ExerciseLogs { get; set; } = new();
    }
}