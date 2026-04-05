using GainBase.Data;
using GainBase.Data.Models;
using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Workout;
using Microsoft.EntityFrameworkCore;
using static GainBase.GCommon.ApplicationConstants;

namespace GainBase.Services.Core
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext dbContext;

        public WorkoutService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkoutExerciseOptionViewModel>> GetPublicExerciseOptionsAsync()
        {
            return await dbContext.Exercises
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .Select(e => new WorkoutExerciseOptionViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    MuscleGroupName = e.MuscleGroup.Name,
                    EquipmentName = e.Equipment.Name
                })
                .ToArrayAsync();
        }

        public async Task<bool> CreateWorkoutAsync(WorkoutFormModel model, string userId)
        {
            List<Guid> selectedExerciseIds = GetDistinctValidExerciseIds(model.SelectedExerciseIds);

            if (!selectedExerciseIds.Any())
            {
                return false;
            }

            int existingExercisesCount = await dbContext.Exercises
                .CountAsync(e => selectedExerciseIds.Contains(e.Id));

            if (existingExercisesCount != selectedExerciseIds.Count)
            {
                return false;
            }

            Workout workout = new Workout
            {
                Name = model.Name,
                Description = model.Description,
                CreatorId = userId
            };

            for (int i = 0; i < selectedExerciseIds.Count; i++)
            {
                workout.WorkoutExercises.Add(new WorkoutExercise
                {
                    ExerciseId = selectedExerciseIds[i],
                    ExecutionOrder = i + 1
                });
            }

            await dbContext.Workouts.AddAsync(workout);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<WorkoutMyViewModel>> GetUserWorkoutsAsync(string userId)
        {
            return await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.CreatorId == userId && !w.IsDeleted)
                .OrderByDescending(w => w.CreatedAt)
                .Select(w => new WorkoutMyViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    ExercisesCount = w.WorkoutExercises.Count,
                    CreatedAt = w.CreatedAt.ToString(DateTimeFormat)
                })
                .ToArrayAsync();
        }

        public async Task<WorkoutDetailsViewModel?> GetWorkoutDetailsAsync(Guid workoutId, string userId)
        {
            return await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.Id == workoutId && w.CreatorId == userId && !w.IsDeleted)
                .Select(w => new WorkoutDetailsViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    CreatedAt = w.CreatedAt.ToString(DateTimeFormat),
                    UpdatedAt = w.UpdatedAt.HasValue ? w.UpdatedAt.Value.ToString(DateTimeFormat) : null,
                    Exercises = w.WorkoutExercises
                        .OrderBy(we => we.ExecutionOrder)
                        .Select(we => new WorkoutDetailsExerciseViewModel
                        {
                            ExerciseId = we.ExerciseId,
                            Name = we.Exercise.Name,
                            MuscleGroupName = we.Exercise.MuscleGroup.Name,
                            EquipmentName = we.Exercise.Equipment.Name
                        })
                        .ToArray()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<WorkoutFormModel?> GetWorkoutForEditAsync(Guid workoutId, string userId)
        {
            return await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.Id == workoutId && w.CreatorId == userId && !w.IsDeleted)
                .Select(w => new WorkoutFormModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    SelectedExerciseIds = w.WorkoutExercises
                        .OrderBy(we => we.ExecutionOrder)
                        .Select(we => we.ExerciseId)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EditWorkoutAsync(Guid workoutId, WorkoutFormModel model, string userId)
        {
            Workout? workout = await dbContext.Workouts
                .Include(w => w.WorkoutExercises)
                .FirstOrDefaultAsync(w => w.Id == workoutId && w.CreatorId == userId && !w.IsDeleted);

            if (workout == null)
            {
                return false;
            }

            List<Guid> selectedExerciseIds = GetDistinctValidExerciseIds(model.SelectedExerciseIds);

            if (!selectedExerciseIds.Any())
            {
                return false;
            }

            int existingExercisesCount = await dbContext.Exercises
                .CountAsync(e => selectedExerciseIds.Contains(e.Id));

            if (existingExercisesCount != selectedExerciseIds.Count)
            {
                return false;
            }

            workout.Name = model.Name;
            workout.Description = model.Description;
            workout.UpdatedAt = DateTime.UtcNow;

            dbContext.WorkoutExercises.RemoveRange(workout.WorkoutExercises);

            List<WorkoutExercise> updatedWorkoutExercises = new();
            for (int i = 0; i < selectedExerciseIds.Count; i++)
            {
                updatedWorkoutExercises.Add(new WorkoutExercise
                {
                    WorkoutId = workout.Id,
                    ExerciseId = selectedExerciseIds[i],
                    ExecutionOrder = i + 1
                });
            }

            await dbContext.WorkoutExercises.AddRangeAsync(updatedWorkoutExercises);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<WorkoutDeleteViewModel?> GetWorkoutForDeleteAsync(Guid workoutId, string userId)
        {
            WorkoutDeleteViewModel? model = await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.Id == workoutId && w.CreatorId == userId && !w.IsDeleted)
                .Select(w => new WorkoutDeleteViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    ExercisesCount = w.WorkoutExercises.Count,
                    CreatedAt = w.CreatedAt.ToString(DateTimeFormat)
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> DeleteWorkoutAsync(Guid workoutId, string userId)
        {
            Workout? workout = await dbContext.Workouts
                .FirstOrDefaultAsync(w => w.Id == workoutId && w.CreatorId == userId && !w.IsDeleted);

            if (workout == null)
            {
                return false;
            }

            workout.IsDeleted = true;
            workout.UpdatedAt = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();
            return true;
        }

        private static List<Guid> GetDistinctValidExerciseIds(IEnumerable<Guid> selectedExerciseIds)
        {
            List<Guid> validIds = new();
            HashSet<Guid> seenIds = new();

            foreach (Guid exerciseId in selectedExerciseIds)
            {
                if (exerciseId == Guid.Empty)
                {
                    continue;
                }

                if (seenIds.Add(exerciseId))
                {
                    validIds.Add(exerciseId);
                }
            }

            return validIds;
        }
    }
}
