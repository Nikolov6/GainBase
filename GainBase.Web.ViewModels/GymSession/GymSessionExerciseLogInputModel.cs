using System.ComponentModel.DataAnnotations;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Web.ViewModels.GymSession
{
    public class GymSessionExerciseLogInputModel
    {
        [Required]
        public Guid ExerciseId { get; set; }

        public string ExerciseName { get; set; } = null!;

        [Required]
        public int ExerciseOrder { get; set; }

        [Required]
        [Range(GymSessionSetsMinValue, GymSessionSetsMaxValue)]
        public int Sets { get; set; }

        [Required]
        [Range(GymSessionRepsMinValue, GymSessionRepsMaxValue)]
        public int Reps { get; set; }
    }
}