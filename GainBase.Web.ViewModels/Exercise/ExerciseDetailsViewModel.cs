namespace GainBase.Web.ViewModels.Exercise
{
    public class ExerciseDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string MuscleGroupName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
        public string Instructions { get; set; } = null!;

        public string CreatorUserName { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public string? UpdatedAt { get; set; }

        public int FavoritesCount { get; set; }

        public bool IsUserAuthenticated { get; set; }
        public bool IsCreatedByCurrentUser { get; set; }
        public bool IsInUserFavorites { get; set; }

        public bool CanEdit => IsCreatedByCurrentUser;
        public bool CanDelete => IsCreatedByCurrentUser;
        public bool CanAddToFavorites => IsUserAuthenticated && !IsCreatedByCurrentUser && !IsInUserFavorites;
        public bool CanRemoveFromFavorites => IsUserAuthenticated && !IsCreatedByCurrentUser && IsInUserFavorites;
    }
}