namespace GainBase.Web.ViewModels.GymSession
{
    public class GymSessionDeleteViewModel
    {
        public Guid Id { get; set; }
        public string WorkoutName { get; set; } = null!;
        public string SessionDate { get; set; } = null!;
        public int DurationMinutes { get; set; }
        public int ExerciseCount { get; set; }
    }
}