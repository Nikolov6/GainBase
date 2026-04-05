using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.GymSession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GainBase.Web.Controllers
{
    [Authorize]
    public class GymSessionsController : BaseController
    {
        private readonly IGymSessionService gymSessionService;
        private readonly ILogger<GymSessionsController> logger;

        public GymSessionsController(
            IGymSessionService gymSessionService,
            ILogger<GymSessionsController> logger)
        {
            this.gymSessionService = gymSessionService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> MySessions()
        {
            string userId = GetCurrentUserId()!;
            IEnumerable<GymSessionListViewModel> sessions = await gymSessionService.GetUserGymSessionsAsync(userId);

            return View(sessions);
        }

        [HttpGet]
        public async Task<IActionResult> SelectWorkout()
        {
            string userId = GetCurrentUserId()!;
            IEnumerable<WorkoutSelectionViewModel> workouts = await gymSessionService.GetUserWorkoutsForSessionAsync(userId);

            return View(workouts);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid workoutId)
        {
            string userId = GetCurrentUserId()!;
            GymSessionCreateFormModel? model = await gymSessionService.GetWorkoutForSessionCreateAsync(workoutId, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Workout was not found or you do not have permission to use it.";
                return RedirectToAction(nameof(SelectWorkout));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GymSessionCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string userId = GetCurrentUserId()!;
                bool created = await gymSessionService.CreateGymSessionAsync(model, userId);

                if (!created)
                {
                    TempData["ErrorMessage"] = "Failed to create gym session. Please try again.";
                    return RedirectToAction(nameof(SelectWorkout));
                }

                TempData["SuccessMessage"] = "Gym session logged successfully!";
                return RedirectToAction(nameof(MySessions));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while creating a gym session.");
                TempData["ErrorMessage"] = "An error occurred. Please try again later.";
                return RedirectToAction(nameof(SelectWorkout));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string userId = GetCurrentUserId()!;
            GymSessionDetailsViewModel? model = await gymSessionService.GetGymSessionDetailsAsync(id, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Gym session was not found.";
                return RedirectToAction(nameof(MySessions));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            string userId = GetCurrentUserId()!;
            GymSessionDeleteViewModel? model = await gymSessionService.GetGymSessionForDeleteAsync(id, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Gym session was not found or you do not have permission to delete it.";
                return RedirectToAction(nameof(MySessions));
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
                bool deleted = await gymSessionService.DeleteGymSessionAsync(id, userId);

                if (!deleted)
                {
                    TempData["ErrorMessage"] = "Gym session was not found or you do not have permission to delete it.";
                    return RedirectToAction(nameof(MySessions));
                }

                TempData["SuccessMessage"] = "Gym session deleted successfully.";
                return RedirectToAction(nameof(MySessions));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while deleting gym session with id {SessionId}.", id);
                TempData["ErrorMessage"] = "An error occurred while deleting the session. Please try again later.";
                return RedirectToAction(nameof(MySessions));
            }
        }
    }
}