using GainBase.Data;
using GainBase.Data.Models;
using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.GymSession;
using Microsoft.EntityFrameworkCore;
using static GainBase.GCommon.ApplicationConstants;

namespace GainBase.Services.Core
{
    public class GymSessionService : IGymSessionService
    {
        private readonly ApplicationDbContext dbContext;

        public GymSessionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkoutSelectionViewModel>> GetUserWorkoutsForSessionAsync(string userId)
        {
            return await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.CreatorId == userId && !w.IsDeleted)
                .OrderBy(w => w.Name)
                .Select(w => new WorkoutSelectionViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    ExercisesCount = w.WorkoutExercises.Count
                })
                .ToArrayAsync();
        }

        public async Task<GymSessionCreateFormModel?> GetWorkoutForSessionCreateAsync(Guid workoutId, string userId)
        {
            var workout = await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.Id == workoutId && w.CreatorId == userId && !w.IsDeleted)
                .Select(w => new
                {
                    w.Id,
                    w.Name,
                    Exercises = w.WorkoutExercises
                        .OrderBy(we => we.ExecutionOrder)
                        .Select(we => new
                        {
                            we.ExerciseId,
                            we.Exercise.Name,
                            we.ExecutionOrder
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (workout == null)
            {
                return null;
            }

            return new GymSessionCreateFormModel
            {
                WorkoutId = workout.Id,
                WorkoutName = workout.Name,
                SessionDate = DateTime.Today,
                DurationMinutes = 60,
                ExerciseLogs = workout.Exercises
                    .Select(e => new GymSessionExerciseLogInputModel
                    {
                        ExerciseId = e.ExerciseId,
                        ExerciseName = e.Name,
                        ExerciseOrder = e.ExecutionOrder,
                        Sets = 3,
                        Reps = 10
                    })
                    .ToList()
            };
        }

        public async Task<bool> CreateGymSessionAsync(GymSessionCreateFormModel model, string userId)
        {
            var workoutData = await dbContext.Workouts
                .AsNoTracking()
                .Where(w => w.Id == model.WorkoutId && w.CreatorId == userId && !w.IsDeleted)
                .Select(w => new
                {
                    w.Id,
                    Exercises = w.WorkoutExercises
                        .Select(we => new
                        {
                            we.ExerciseId,
                            we.ExecutionOrder
                        })
                        .ToArray()
                })
                .FirstOrDefaultAsync();

            if (workoutData == null)
            {
                return false;
            }

            var allowedExerciseOrderById = workoutData.Exercises
                .ToDictionary(e => e.ExerciseId, e => e.ExecutionOrder);

            var postedLogsByExerciseId = model.ExerciseLogs
                .Where(e => e.ExerciseId != Guid.Empty && allowedExerciseOrderById.ContainsKey(e.ExerciseId))
                .GroupBy(e => e.ExerciseId)
                .ToDictionary(g => g.Key, g => g.First());

            if (!postedLogsByExerciseId.Any())
            {
                return false;
            }

            var gymSession = new GymSession
            {
                WorkoutId = model.WorkoutId,
                UserId = userId,
                SessionDate = model.SessionDate,
                DurationMinutes = model.DurationMinutes,
                Note = model.Note
            };

            foreach (var workoutExercise in workoutData.Exercises.OrderBy(e => e.ExecutionOrder))
            {
                if (!postedLogsByExerciseId.TryGetValue(workoutExercise.ExerciseId, out GymSessionExerciseLogInputModel? postedLog))
                {
                    continue;
                }

                gymSession.ExerciseLogs.Add(new GymSessionExerciseLog
                {
                    ExerciseId = workoutExercise.ExerciseId,
                    ExerciseOrder = workoutExercise.ExecutionOrder,
                    Sets = postedLog.Sets,
                    Reps = postedLog.Reps
                });
            }

            await dbContext.GymSessions.AddAsync(gymSession);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GymSessionListViewModel>> GetUserGymSessionsAsync(string userId)
        {
            return await dbContext.GymSessions
                .AsNoTracking()
                .Where(gs => gs.UserId == userId)
                .OrderByDescending(gs => gs.SessionDate)
                .ThenByDescending(gs => gs.CreatedAt)
                .Select(gs => new GymSessionListViewModel
                {
                    Id = gs.Id,
                    WorkoutName = gs.Workout.Name,
                    SessionDate = gs.SessionDate.ToString(DateTimeFormat),
                    DurationMinutes = gs.DurationMinutes,
                    ExerciseCount = gs.ExerciseLogs.Count
                })
                .ToArrayAsync();
        }

        public async Task<GymSessionDetailsViewModel?> GetGymSessionDetailsAsync(Guid sessionId, string userId)
        {
            return await dbContext.GymSessions
                .AsNoTracking()
                .Where(gs => gs.Id == sessionId && gs.UserId == userId)
                .Select(gs => new GymSessionDetailsViewModel
                {
                    Id = gs.Id,
                    WorkoutName = gs.Workout.Name,
                    SessionDate = gs.SessionDate.ToString(DateTimeFormat),
                    DurationMinutes = gs.DurationMinutes,
                    Note = gs.Note,
                    CreatedAt = gs.CreatedAt.ToString(DateTimeFormat),
                    ExerciseLogs = gs.ExerciseLogs
                        .OrderBy(el => el.ExerciseOrder)
                        .Select(el => new GymSessionExerciseLogViewModel
                        {
                            ExerciseName = el.Exercise.Name,
                            Sets = el.Sets,
                            Reps = el.Reps,
                            ExerciseOrder = el.ExerciseOrder
                        })
                        .ToArray()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<GymSessionDeleteViewModel?> GetGymSessionForDeleteAsync(Guid sessionId, string userId)
        {
            return await dbContext.GymSessions
                .AsNoTracking()
                .Where(gs => gs.Id == sessionId && gs.UserId == userId)
                .Select(gs => new GymSessionDeleteViewModel
                {
                    Id = gs.Id,
                    WorkoutName = gs.Workout.Name,
                    SessionDate = gs.SessionDate.ToString(DateTimeFormat),
                    DurationMinutes = gs.DurationMinutes,
                    ExerciseCount = gs.ExerciseLogs.Count
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteGymSessionAsync(Guid sessionId, string userId)
        {
            var gymSession = await dbContext.GymSessions
                .Include(gs => gs.ExerciseLogs)
                .FirstOrDefaultAsync(gs => gs.Id == sessionId && gs.UserId == userId);

            if (gymSession == null)
            {
                return false;
            }

            dbContext.GymSessionExerciseLogs.RemoveRange(gymSession.ExerciseLogs);
            dbContext.GymSessions.Remove(gymSession);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}