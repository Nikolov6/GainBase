using GainBase.Data;
using GainBase.Data.Models;
using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Exercise;
using Microsoft.EntityFrameworkCore;
using static GainBase.GCommon.ApplicationConstants;

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

        public async Task CreateExerciseAsync(ExerciseFormModel model, string userId)
        {
            Exercise newExercise = new Exercise
            {
                Name = model.Name,
                Description = model.Description,
                MuscleGroupId = model.MuscleGroupId,
                EquipmentId = model.EquipmentId,
                Instructions = model.Instructions,
                CreatorId = userId,
            };

            await dbContext.Exercises.AddAsync(newExercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseFavoriteViewModel>> GetUserFavoritesAsync(string userId)
        {
            IEnumerable<ExerciseFavoriteViewModel> userFavorites = await dbContext.Exercises
                .Include(e => e.MuscleGroup)
                .Include(e => e.Equipment)
                .Include(e => e.UserExercises)
                .AsNoTracking()
                .Where(e => e.UserExercises.Any(ue => ue.UserId == userId))
                .Select(e => new ExerciseFavoriteViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    SavedAt = e.UserExercises
                        .Where(ue => ue.UserId == userId)
                        .Select(ue => ue.SavedAt)
                        .FirstOrDefault()
                        .ToString(DateTimeFormat)
                })
                .OrderBy(e => e.Name)
                .ThenBy(e => e.MuscleGroupName)
                .ToArrayAsync();

            return userFavorites;
        }

        public async Task AddToUserFavoritesAsync(Guid exerciseId, string userId)
        {
            Exercise? exercise = await dbContext.Exercises
                .FindAsync(exerciseId);

            if (exercise != null)
            {
                UserExercise newUserExercise = new UserExercise
                {
                    ExerciseId = exerciseId,
                    UserId = userId
                };

                await dbContext.UsersExercises.AddAsync(newUserExercise);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExerciseInUserFavoritesAsync(Guid exerciseId, string userId)
        {
            bool isInFavorites = await dbContext.UsersExercises
                .AnyAsync(ue => ue.ExerciseId == exerciseId && ue.UserId == userId);

            return isInFavorites;
        }

        public async Task<bool> IsExerciseCreatorAsync(Guid exerciseId, string userId)
        {
            bool isCreator = await dbContext.Exercises
                .AnyAsync(e => e.Id == exerciseId && e.CreatorId == userId);

            return isCreator;
        }

        public Task RemoveFromUserFavoritesAsync(Guid exerciseId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
