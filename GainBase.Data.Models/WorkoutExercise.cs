using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GainBase.Data.Models
{
    [PrimaryKey(nameof(WorkoutId), nameof(ExerciseId))]
    public class WorkoutExercise
    {
        [Required]
        public Guid WorkoutId { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public int ExecutionOrder { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        [ForeignKey(nameof(ExerciseId))]
        public virtual Exercise Exercise { get; set; } = null!;
    }
}