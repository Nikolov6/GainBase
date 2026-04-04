using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GainBase.Web.Controllers
{
    [Authorize]
    public class WorkoutsController : BaseController
    {
        private readonly IWorkoutService workoutService;
        private readonly ILogger<WorkoutsController> logger;

        public WorkoutsController(IWorkoutService workoutService, ILogger<WorkoutsController> logger)
        {
            this.workoutService = workoutService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> MyWorkouts()
        {
            string userId = GetCurrentUserId()!;
            IEnumerable<WorkoutMyViewModel> myWorkouts = await workoutService.GetUserWorkoutsAsync(userId);

            return View(myWorkouts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            WorkoutFormModel model = new WorkoutFormModel
            {
                AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutFormModel model)
        {
            if (!model.SelectedExerciseIds.Any())
            {
                ModelState.AddModelError(nameof(model.SelectedExerciseIds), "Please select at least one exercise.");
            }

            if (!ModelState.IsValid)
            {
                model.AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync();
                return View(model);
            }

            try
            {
                string userId = GetCurrentUserId()!;
                bool created = await workoutService.CreateWorkoutAsync(model, userId);

                if (!created)
                {
                    ModelState.AddModelError(string.Empty, "One or more selected exercises are invalid.");
                    model.AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync();
                    return View(model);
                }

                TempData["SuccessMessage"] = "Workout created successfully.";
                return RedirectToAction(nameof(MyWorkouts));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while creating a workout.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the workout. Please try again later.");
                model.AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string userId = GetCurrentUserId()!;
            WorkoutFormModel? model = await workoutService.GetWorkoutForEditAsync(id, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Workout was not found or you do not have permission to edit it.";
                return RedirectToAction(nameof(MyWorkouts));
            }

            model.AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, WorkoutFormModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!model.SelectedExerciseIds.Any())
            {
                ModelState.AddModelError(nameof(model.SelectedExerciseIds), "Please select at least one exercise.");
            }

            if (!ModelState.IsValid)
            {
                model.AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync();
                return View(model);
            }

            try
            {
                string userId = GetCurrentUserId()!;
                bool edited = await workoutService.EditWorkoutAsync(id, model, userId);

                if (!edited)
                {
                    TempData["ErrorMessage"] = "Workout was not found or your selected exercises were invalid.";
                    return RedirectToAction(nameof(MyWorkouts));
                }

                TempData["SuccessMessage"] = "Workout updated successfully.";
                return RedirectToAction(nameof(MyWorkouts));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while editing workout with id {WorkoutId}.", id);
                ModelState.AddModelError(string.Empty, "An error occurred while editing the workout. Please try again later.");
                model.AvailableExercises = await workoutService.GetPublicExerciseOptionsAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string userId = GetCurrentUserId()!;
            WorkoutDetailsViewModel? model = await workoutService.GetWorkoutDetailsAsync(id, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Workout was not found.";
                return RedirectToAction(nameof(MyWorkouts));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            string userId = GetCurrentUserId()!;
            WorkoutDeleteViewModel? model = await workoutService.GetWorkoutForDeleteAsync(id, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Workout was not found or you do not have permission to delete it.";
                return RedirectToAction(nameof(MyWorkouts));
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                string userId = GetCurrentUserId()!;
                bool deleted = await workoutService.DeleteWorkoutAsync(id, userId);

                if (!deleted)
                {
                    TempData["ErrorMessage"] = "Workout was not found or you do not have permission to delete it.";
                    return RedirectToAction(nameof(MyWorkouts));
                }

                TempData["SuccessMessage"] = "Workout deleted successfully.";
                return RedirectToAction(nameof(MyWorkouts));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while deleting workout with id {WorkoutId}.", id);
                TempData["ErrorMessage"] = "An error occurred while deleting the workout. Please try again later.";
                return RedirectToAction(nameof(MyWorkouts));
            }
        }
    }
}