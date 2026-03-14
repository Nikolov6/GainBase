using GainBase.Data;
using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GainBase.Services.Core
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExerciseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ExerciseIndexViewModel>> GetAllExercisesAsync(string? currentUserId)
        {
            IEnumerable<ExerciseIndexViewModel> allExercises = await dbContext.Exercises
                .Include(e => e.MuscleGroup)
                .Include(e => e.Equipment)
                .Include(e => e.UserExercises)
                .AsNoTracking()
                .Select(e => new ExerciseIndexViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    FavoritesCount = e.UserExercises.Count,
                    IsCreatedByCurrentUser = e.CreatorId == currentUserId,
                    IsInUserFavorites = e.UserExercises.Any(ue => ue.UserId == currentUserId)
                })
                .OrderByDescending(e => e.FavoritesCount)
                .ThenBy(e => e.Name)
                .ThenBy(e => e.MuscleGroupName)
                .ToArrayAsync();

            return allExercises;
        }

       
    }
}
