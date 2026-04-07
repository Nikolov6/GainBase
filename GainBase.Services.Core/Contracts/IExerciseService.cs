using GainBase.Web.ViewModels.Exercise;

namespace GainBase.Services.Core.Contracts
{
    public interface IExerciseService
    {
        Task<(IEnumerable<ExerciseIndexViewModel> Exercises, int TotalExercises)> GetAllExercisesAsync(AllExercisesQueryModel queryModel, string? currentUserId);
        Task<ExerciseDetailsViewModel?> GetExerciseDetailsAsync(Guid exerciseId, string? currentUserId);
        Task CreateExerciseAsync(ExerciseFormModel model, string userId);
        Task<IEnumerable<ExerciseFavoriteViewModel>> GetUserFavoritesAsync(string userId);
        Task<IEnumerable<ExerciseMyViewModel>> GetUserCreatedExercisesAsync(string userId);
        Task AddToUserFavoritesAsync(Guid exerciseId, string userId);
        Task RemoveFromUserFavoritesAsync(Guid exerciseId, string userId);
        Task<bool> IsExerciseInUserFavoritesAsync(Guid exerciseId, string userId);
        Task<bool> IsExerciseCreatorAsync(Guid exerciseId, string userId);
        Task<ExerciseFormModel?> GetExerciseForEditAsync(Guid exerciseId, string userId);
        Task<bool> EditExerciseAsync(Guid exerciseId, ExerciseFormModel model, string userId);
        Task<ExerciseDeleteViewModel?> GetExerciseForDeleteAsync(Guid exerciseId, string userId);
        Task<bool> DeleteExerciseAsync(Guid exerciseId, string userId);

        Task<IEnumerable<ExerciseMyViewModel>> GetAllExercisesForAdminAsync();
        Task<ExerciseFormModel?> GetExerciseForEditByAdminAsync(Guid exerciseId);
        Task<bool> EditExerciseByAdminAsync(Guid exerciseId, ExerciseFormModel model);
        Task<ExerciseDeleteViewModel?> GetExerciseForDeleteByAdminAsync(Guid exerciseId);
        Task<bool> DeleteExerciseByAdminAsync(Guid exerciseId);
    }
}
