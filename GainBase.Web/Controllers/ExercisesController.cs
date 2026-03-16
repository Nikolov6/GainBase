using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Equipment;
using GainBase.Web.ViewModels.Exercise;
using GainBase.Web.ViewModels.MuscleGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GainBase.Web.Controllers
{
    public class ExercisesController : BaseController
    {
        private readonly IExerciseService exerciseService;
        private readonly IEquipmentService equipmentService;
        private readonly IMuscleGroupService muscleGroupService;

        private readonly ILogger<ExercisesController> logger;

        public ExercisesController(IExerciseService exerciseService, IEquipmentService equipmentService,
            IMuscleGroupService muscleGroupService, ILogger<ExercisesController> logger)
        {
            this.exerciseService = exerciseService;
            this.equipmentService = equipmentService;
            this.muscleGroupService = muscleGroupService;

            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? currentUserId = GetCurrentUserId();
            IEnumerable<ExerciseIndexViewModel> exercises = await exerciseService.GetAllExercisesAsync(currentUserId);
            return View(exercises);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ExerciseFormModel model = new ExerciseFormModel();
            await PopulateExerciseFormCollectionsAsync(model);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ExerciseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            bool muscleGroupExists = await muscleGroupService.ExistsByIdAsync(model.MuscleGroupId);
            if (!muscleGroupExists)
            {
                ModelState.AddModelError(nameof(model.MuscleGroupId), "Selected muscle group does not exist.");
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            bool equipmentExists = await equipmentService.ExistsByIdAsync(model.EquipmentId);
            if (!equipmentExists)
            {
                ModelState.AddModelError(nameof(model.EquipmentId), "Selected equipment does not exist.");
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            try
            {
                string userId = GetCurrentUserId()!;
                await exerciseService.CreateExerciseAsync(model, userId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while creating an exercise.");

                ModelState.AddModelError(string.Empty, "An error occurred while creating the exercise. Please try again later.");
                await PopulateExerciseFormCollectionsAsync(model);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            string userId = GetCurrentUserId()!;
            ExerciseFormModel? model = await exerciseService.GetExerciseForEditAsync(id, userId);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Exercise was not found or you do not have permission to edit it.";
                return RedirectToAction(nameof(MyExercises));
            }

            await PopulateExerciseFormCollectionsAsync(model);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id, ExerciseFormModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            bool muscleGroupExists = await muscleGroupService.ExistsByIdAsync(model.MuscleGroupId);
            if (!muscleGroupExists)
            {
                ModelState.AddModelError(nameof(model.MuscleGroupId), "Selected muscle group does not exist.");
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            bool equipmentExists = await equipmentService.ExistsByIdAsync(model.EquipmentId);
            if (!equipmentExists)
            {
                ModelState.AddModelError(nameof(model.EquipmentId), "Selected equipment does not exist.");
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            try
            {
                string userId = GetCurrentUserId()!;
                bool isEdited = await exerciseService.EditExerciseAsync(id, model, userId);

                if (!isEdited)
                {
                    TempData["ErrorMessage"] = "Exercise was not found or you do not have permission to edit it.";
                    return RedirectToAction(nameof(MyExercises));
                }

                TempData["SuccessMessage"] = "Exercise updated successfully.";
                return RedirectToAction(nameof(MyExercises));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while editing exercise with id {ExerciseId}.", id);

                ModelState.AddModelError(string.Empty, "An error occurred while editing the exercise. Please try again later.");
                await PopulateExerciseFormCollectionsAsync(model);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyFavorites()
        {
            string userId = GetCurrentUserId()!;
            IEnumerable<ExerciseFavoriteViewModel> favoriteExercises = await exerciseService.GetUserFavoritesAsync(userId);
            return View(favoriteExercises);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyExercises()
        {
            string userId = GetCurrentUserId()!;
            IEnumerable<ExerciseMyViewModel> myExercises = await exerciseService.GetUserCreatedExercisesAsync(userId);
            return View(myExercises);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToFavorites(Guid exerciseId)
        {
            string userId = GetCurrentUserId()!;

            bool isUserCreator = await exerciseService.IsExerciseCreatorAsync(exerciseId, userId);
            if (isUserCreator)
            {
                TempData["ErrorMessage"] = "You cannot add your own exercise to favorites.";
                return RedirectToAction(nameof(Index));
            }

            bool isAlreadyInFavorites = await exerciseService.IsExerciseInUserFavoritesAsync(exerciseId, userId);
            if (!isAlreadyInFavorites)
            {
                try
                {
                    await exerciseService.AddToUserFavoritesAsync(exerciseId, userId);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "An error occurred while adding the exercise to favorites. Please try again later.");
                    TempData["ErrorMessage"] = "An error occurred while adding the exercise to favorites. Please try again later.";
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromFavorites(Guid exerciseId)
        {
            string userId = GetCurrentUserId()!;

            bool isAlreadyInFavorites = await exerciseService.IsExerciseInUserFavoritesAsync(exerciseId, userId);
            if (isAlreadyInFavorites)
            {
                try
                {
                    await exerciseService.RemoveFromUserFavoritesAsync(exerciseId, userId);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "An error occurred while removing the exercise from favorites. Please try again later.");
                    TempData["ErrorMessage"] = "An error occurred while removing the exercise from favorites. Please try again later.";
                }
            }

            return RedirectToAction(nameof(MyFavorites));
        }

        private async Task PopulateExerciseFormCollectionsAsync(ExerciseFormModel model)
        {
            IEnumerable<EquipmentViewModel> equipment = await equipmentService.GetAllEquipmentAsync();
            IEnumerable<MuscleGroupViewModel> muscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();

            model.Equipment = equipment;
            model.MuscleGroups = muscleGroups;
        }
    }
}