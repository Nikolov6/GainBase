using System.ComponentModel.DataAnnotations;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Web.ViewModels.Workout
{
    public class WorkoutFormModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(WorkoutNameMaxLength, MinimumLength = WorkoutNameMinLength)]
        public string Name { get; set; } = null!;

        [StringLength(WorkoutDescriptionMaxLength, MinimumLength = WorkoutDescriptionMinLength)]
        public string? Description { get; set; }

        public List<Guid> SelectedExerciseIds { get; set; } = new();

        public IEnumerable<WorkoutExerciseOptionViewModel> AvailableExercises { get; set; }
            = new HashSet<WorkoutExerciseOptionViewModel>();
    }
}