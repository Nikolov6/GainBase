using GainBase.Data;
using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Equipment;
using GainBase.Web.ViewModels.MuscleGroup;
using Microsoft.EntityFrameworkCore;

namespace GainBase.Services.Core
{
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly ApplicationDbContext dbContext;

        public MuscleGroupService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MuscleGroupViewModel>> GetAllMuscleGroupsAsync()
        {
            IEnumerable<MuscleGroupViewModel> allMuscleGroups = await dbContext.MuscleGroups
                .AsNoTracking()
                .Select(e => new MuscleGroupViewModel
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .OrderBy(e => e.Id)
                .ToArrayAsync();

            return allMuscleGroups;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool muscleGroupExists = await dbContext.MuscleGroups
                .AsNoTracking()
                .AnyAsync(e => e.Id == id);

            return muscleGroupExists;
        }
    }
}
