namespace GainBase.Web.ViewModels
{
    public class ExerciseIndexViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string MuscleGroupName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
        public int FavoritesCount { get; set; }
        public bool IsCreatedByCurrentUser { get; set; }
        public bool IsInUserFavorites { get; set; }
    }
}