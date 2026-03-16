namespace GainBase.Web.ViewModels.Exercise
{
    public class ExerciseDeleteViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string MuscleGroupName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;

        public string CreatedAt { get; set; } = null!;
        public int FavoritesCount { get; set; }
    }
}