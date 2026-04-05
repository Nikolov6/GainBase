using GainBase.Web.ViewModels.GymSession;

namespace GainBase.Services.Core.Contracts
{
    public interface IGymSessionService
    {
        Task<IEnumerable<WorkoutSelectionViewModel>> GetUserWorkoutsForSessionAsync(string userId);
        Task<GymSessionCreateFormModel?> GetWorkoutForSessionCreateAsync(Guid workoutId, string userId);
        Task<bool> CreateGymSessionAsync(GymSessionCreateFormModel model, string userId);
        Task<IEnumerable<GymSessionListViewModel>> GetUserGymSessionsAsync(string userId);
        Task<GymSessionDetailsViewModel?> GetGymSessionDetailsAsync(Guid sessionId, string userId);
        Task<GymSessionDeleteViewModel?> GetGymSessionForDeleteAsync(Guid sessionId, string userId);
        Task<bool> DeleteGymSessionAsync(Guid sessionId, string userId);
    }
}