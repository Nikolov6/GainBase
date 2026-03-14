using GainBase.Web.ViewModels;

namespace GainBase.Services.Core.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseIndexViewModel>> GetAllExercisesAsync(string? currentUserId);
    }
}
