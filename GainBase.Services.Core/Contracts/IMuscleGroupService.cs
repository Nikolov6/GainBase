using GainBase.Web.ViewModels.MuscleGroup;

namespace GainBase.Services.Core.Contracts
{
    public interface IMuscleGroupService
    {
        Task<IEnumerable<MuscleGroupViewModel>> GetAllMuscleGroupsAsync();
        Task<bool> ExistsByIdAsync(int id);
    }
}
