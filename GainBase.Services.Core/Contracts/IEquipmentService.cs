using GainBase.Web.ViewModels.Equipment;

namespace GainBase.Services.Core.Contracts
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentViewModel>> GetAllEquipmentAsync();
    }
}
