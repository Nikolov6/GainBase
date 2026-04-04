namespace GainBase.Web.ViewModels.Workout
{
    public class WorkoutDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int ExercisesCount { get; set; }
        public string CreatedAt { get; set; } = null!;
    }
}