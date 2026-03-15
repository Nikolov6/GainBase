using GainBase.Data;
using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Equipment;
using Microsoft.EntityFrameworkCore;
namespace GainBase.Services.Core
{

    public class EquipmentService : IEquipmentService
    {
        private readonly ApplicationDbContext dbContext;

        public EquipmentService(ApplicationDbContext dbContext)
        {
           this.dbContext = dbContext; 
        }

        public async Task<IEnumerable<EquipmentViewModel>> GetAllEquipmentAsync()
        {
            IEnumerable<EquipmentViewModel> AllEquipment = await dbContext.Equipment
                .AsNoTracking()
                .Select(e => new EquipmentViewModel
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .OrderBy(e => e.Id)
                .ToArrayAsync();

            return AllEquipment;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool equipmentExists = await dbContext.Equipment
                .AsNoTracking()
                .AnyAsync(e => e.Id == id);

            return equipmentExists;
        }
    }
}
