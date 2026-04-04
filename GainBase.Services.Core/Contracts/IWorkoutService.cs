using GainBase.Web.ViewModels.Workout;

namespace GainBase.Services.Core.Contracts
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutExerciseOptionViewModel>> GetPublicExerciseOptionsAsync();
        Task<bool> CreateWorkoutAsync(WorkoutFormModel model, string userId);
        Task<IEnumerable<WorkoutMyViewModel>> GetUserWorkoutsAsync(string userId);
        Task<WorkoutDetailsViewModel?> GetWorkoutDetailsAsync(Guid workoutId, string userId);

        Task<WorkoutFormModel?> GetWorkoutForEditAsync(Guid workoutId, string userId);
        Task<bool> EditWorkoutAsync(Guid workoutId, WorkoutFormModel model, string userId);

        Task<WorkoutDeleteViewModel?> GetWorkoutForDeleteAsync(Guid workoutId, string userId);
        Task<bool> DeleteWorkoutAsync(Guid workoutId, string userId);
    }
}
