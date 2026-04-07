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

        public async Task<IEnumerable<ExerciseIndexViewModel>> GetAllExercisesAsync(AllExercisesQueryModel queryModel, string? currentUserId)
        {
            IQueryable<Exercise> exercisesQuery = dbContext.Exercises
                .Include(e => e.MuscleGroup)
                .Include(e => e.Equipment)
                .Include(e => e.UserExercises)
                .Where(e => !e.IsDeleted)
                .AsNoTracking();

            if (queryModel.MuscleGroupId.HasValue)
            {
                exercisesQuery = exercisesQuery
                    .Where(e => e.MuscleGroupId == queryModel.MuscleGroupId.Value);
            }

            if (queryModel.EquipmentId.HasValue)
            {
                exercisesQuery = exercisesQuery
                    .Where(e => e.EquipmentId == queryModel.EquipmentId.Value);
            }

            IEnumerable<ExerciseIndexViewModel> allExercises = await exercisesQuery
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

        public async Task<ExerciseDetailsViewModel?> GetExerciseDetailsAsync(Guid exerciseId, string? currentUserId)
        {
            ExerciseDetailsViewModel? details = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => e.Id == exerciseId && !e.IsDeleted)
                .Select(e => new ExerciseDetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    Instructions = e.Instructions,
                    CreatorUserName = e.Creator.UserName ?? "Unknown",
                    CreatedAt = e.CreatedAt.ToString(DateTimeFormat),
                    UpdatedAt = e.UpdatedAt.HasValue
                        ? e.UpdatedAt.Value.ToString(DateTimeFormat)
                        : null,
                    FavoritesCount = e.UserExercises.Count,
                    IsUserAuthenticated = !string.IsNullOrWhiteSpace(currentUserId),
                    IsCreatedByCurrentUser = e.CreatorId == currentUserId,
                    IsInUserFavorites = e.UserExercises.Any(ue => ue.UserId == currentUserId)
                })
                .FirstOrDefaultAsync();

            return details;
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
            IEnumerable<ExerciseFavoriteViewModel> userFavorites = await dbContext.UsersExercises
                .AsNoTracking()
                .Where(ue => ue.UserId == userId && !ue.Exercise.IsDeleted)
                .OrderByDescending(ue => ue.SavedAt)
                .Select(ue => new ExerciseFavoriteViewModel
                {
                    Id = ue.Exercise.Id,
                    Name = ue.Exercise.Name,
                    MuscleGroupName = ue.Exercise.MuscleGroup.Name,
                    EquipmentName = ue.Exercise.Equipment.Name,
                    SavedAt = ue.SavedAt.ToString(DateTimeFormat)
                })
                .ToArrayAsync();

            return userFavorites;
        }

        public async Task<IEnumerable<ExerciseMyViewModel>> GetUserCreatedExercisesAsync(string userId)
        {
            IEnumerable<ExerciseMyViewModel> myExercises = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => e.CreatorId == userId && !e.IsDeleted)
                .OrderByDescending(e => e.CreatedAt)
                .Select(e => new ExerciseMyViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    CreatedAt = e.CreatedAt.ToString(DateTimeFormat)
                })
                .ToArrayAsync();

            return myExercises;
        }

        public async Task AddToUserFavoritesAsync(Guid exerciseId, string userId)
        {
            Exercise? exercise = await dbContext.Exercises
                .FirstOrDefaultAsync(e => e.Id == exerciseId && !e.IsDeleted);

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
                .AnyAsync(e => e.Id == exerciseId && e.CreatorId == userId && !e.IsDeleted);

            return isCreator;
        }

        public async Task RemoveFromUserFavoritesAsync(Guid exerciseId, string userId)
        {
            UserExercise? userExerciseToRemove = await dbContext.UsersExercises
                .AsNoTracking()
                .FirstOrDefaultAsync(ue => ue.ExerciseId == exerciseId && ue.UserId == userId);

            if (userExerciseToRemove != null)
            {
                dbContext.UsersExercises.Remove(userExerciseToRemove);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ExerciseFormModel?> GetExerciseForEditAsync(Guid exerciseId, string userId)
        {
            ExerciseFormModel? model = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => e.Id == exerciseId && e.CreatorId == userId && !e.IsDeleted)
                .Select(e => new ExerciseFormModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupId = e.MuscleGroupId,
                    EquipmentId = e.EquipmentId,
                    Instructions = e.Instructions
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> EditExerciseAsync(Guid exerciseId, ExerciseFormModel model, string userId)
        {
            Exercise? exerciseToEdit = await dbContext.Exercises
                .FirstOrDefaultAsync(e => e.Id == exerciseId && e.CreatorId == userId && !e.IsDeleted);

            if (exerciseToEdit == null)
            {
                return false;
            }

            exerciseToEdit.Name = model.Name;
            exerciseToEdit.Description = model.Description;
            exerciseToEdit.MuscleGroupId = model.MuscleGroupId;
            exerciseToEdit.EquipmentId = model.EquipmentId;
            exerciseToEdit.Instructions = model.Instructions;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ExerciseDeleteViewModel?> GetExerciseForDeleteAsync(Guid exerciseId, string userId)
        {
            ExerciseDeleteViewModel? model = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => e.Id == exerciseId && e.CreatorId == userId && !e.IsDeleted)
                .Select(e => new ExerciseDeleteViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    CreatedAt = e.CreatedAt.ToString(DateTimeFormat),
                    FavoritesCount = e.UserExercises.Count
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> DeleteExerciseAsync(Guid exerciseId, string userId)
        {
            Exercise? exerciseToDelete = await dbContext.Exercises
                .FirstOrDefaultAsync(e => e.Id == exerciseId && e.CreatorId == userId && !e.IsDeleted);

            if (exerciseToDelete == null)
            {
                return false;
            }

            exerciseToDelete.IsDeleted = true;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ExerciseMyViewModel>> GetAllExercisesForAdminAsync()
        {
            IEnumerable<ExerciseMyViewModel> exercises = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.CreatedAt)
                .Select(e => new ExerciseMyViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    CreatedAt = e.CreatedAt.ToString(DateTimeFormat)
                })
                .ToArrayAsync();

            return exercises;
        }

        public async Task<ExerciseFormModel?> GetExerciseForEditByAdminAsync(Guid exerciseId)
        {
            ExerciseFormModel? model = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => e.Id == exerciseId && !e.IsDeleted)
                .Select(e => new ExerciseFormModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupId = e.MuscleGroupId,
                    EquipmentId = e.EquipmentId,
                    Instructions = e.Instructions
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> EditExerciseByAdminAsync(Guid exerciseId, ExerciseFormModel model)
        {
            Exercise? exerciseToEdit = await dbContext.Exercises
                .FirstOrDefaultAsync(e => e.Id == exerciseId && !e.IsDeleted);

            if (exerciseToEdit == null)
            {
                return false;
            }

            exerciseToEdit.Name = model.Name;
            exerciseToEdit.Description = model.Description;
            exerciseToEdit.MuscleGroupId = model.MuscleGroupId;
            exerciseToEdit.EquipmentId = model.EquipmentId;
            exerciseToEdit.Instructions = model.Instructions;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ExerciseDeleteViewModel?> GetExerciseForDeleteByAdminAsync(Guid exerciseId)
        {
            ExerciseDeleteViewModel? model = await dbContext.Exercises
                .AsNoTracking()
                .Where(e => e.Id == exerciseId && !e.IsDeleted)
                .Select(e => new ExerciseDeleteViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name,
                    CreatedAt = e.CreatedAt.ToString(DateTimeFormat),
                    FavoritesCount = e.UserExercises.Count
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> DeleteExerciseByAdminAsync(Guid exerciseId)
        {
            Exercise? exerciseToDelete = await dbContext.Exercises
                .FirstOrDefaultAsync(e => e.Id == exerciseId && !e.IsDeleted);

            if (exerciseToDelete == null)
            {
                return false;
            }

            exerciseToDelete.IsDeleted = true;

            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
