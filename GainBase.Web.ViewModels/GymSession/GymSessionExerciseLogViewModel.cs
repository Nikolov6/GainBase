namespace GainBase.Web.ViewModels.GymSession
{
    public class GymSessionExerciseLogViewModel
    {
        public string ExerciseName { get; set; } = null!;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int ExerciseOrder { get; set; }
    }
}