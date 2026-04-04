namespace GainBase.Web.ViewModels.Workout
{
    public class WorkoutDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string CreatedAt { get; set; } = null!;
        public string? UpdatedAt { get; set; }

        public IEnumerable<WorkoutDetailsExerciseViewModel> Exercises { get; set; }
            = new HashSet<WorkoutDetailsExerciseViewModel>();
    }
}