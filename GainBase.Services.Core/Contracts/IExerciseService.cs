using GainBase.Web.ViewModels.Exercise;

namespace GainBase.Services.Core.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseIndexViewModel>> GetAllExercisesAsync(string? currentUserId);
    }
}
