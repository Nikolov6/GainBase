using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Data.Models
{
    [PrimaryKey(nameof(GymSessionId), nameof(ExerciseId))]
    public class GymSessionExerciseLog
    {
        [Required]
        public Guid GymSessionId { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public int ExerciseOrder { get; set; }

        [Required]
        [Range(GymSessionSetsMinValue, GymSessionSetsMaxValue)]
        public int Sets { get; set; }

        [Required]
        [Range(GymSessionRepsMinValue, GymSessionRepsMaxValue)]
        public int Reps { get; set; }

        [ForeignKey(nameof(GymSessionId))]
        public virtual GymSession GymSession { get; set; } = null!;

        [ForeignKey(nameof(ExerciseId))]
        public virtual Exercise Exercise { get; set; } = null!;
    }
}