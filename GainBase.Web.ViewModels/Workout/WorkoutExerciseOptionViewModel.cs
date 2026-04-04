namespace GainBase.Web.ViewModels.Workout
{
    public class WorkoutExerciseOptionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string MuscleGroupName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
    }
}