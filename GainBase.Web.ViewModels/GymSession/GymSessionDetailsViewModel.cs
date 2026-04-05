namespace GainBase.Web.ViewModels.GymSession
{
    public class GymSessionDetailsViewModel
    {
        public Guid Id { get; set; }
        public string WorkoutName { get; set; } = null!;
        public string SessionDate { get; set; } = null!;
        public int DurationMinutes { get; set; }
        public string? Note { get; set; }
        public string CreatedAt { get; set; } = null!;

        public IEnumerable<GymSessionExerciseLogViewModel> ExerciseLogs { get; set; }
            = new HashSet<GymSessionExerciseLogViewModel>();
    }
}