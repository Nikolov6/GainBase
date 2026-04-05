namespace GainBase.Web.ViewModels.GymSession
{
    public class WorkoutSelectionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int ExercisesCount { get; set; }
    }
}