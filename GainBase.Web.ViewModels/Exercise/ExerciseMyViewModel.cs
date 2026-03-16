namespace GainBase.Web.ViewModels.Exercise
{
    public class ExerciseMyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string MuscleGroupName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
    }
}