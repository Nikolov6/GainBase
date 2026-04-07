using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels.Equipment;
using GainBase.Web.ViewModels.Exercise;
using GainBase.Web.ViewModels.MuscleGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GainBase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExercisesManagementController : BaseController
    {
        private readonly IExerciseService exerciseService;
        private readonly IEquipmentService equipmentService;
        private readonly IMuscleGroupService muscleGroupService;
        private readonly ILogger<ExercisesManagementController> logger;

        public ExercisesManagementController(
            IExerciseService exerciseService,
            IEquipmentService equipmentService,
            IMuscleGroupService muscleGroupService,
            ILogger<ExercisesManagementController> logger)
        {
            this.exerciseService = exerciseService;
            this.equipmentService = equipmentService;
            this.muscleGroupService = muscleGroupService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllExercisesQueryModel queryModel)
        {
            await PopulateExerciseQueryCollectionsAsync(queryModel);
            queryModel.Exercises = await exerciseService.GetAllExercisesAsync(queryModel, null);

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            ExerciseDetailsViewModel? model = await exerciseService.GetExerciseDetailsAsync(id, null);
            if (model == null)
            {
                TempData["ErrorMessage"] = "Exercise was not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ExerciseFormModel model = new ExerciseFormModel();
            await PopulateExerciseFormCollectionsAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExerciseFormModel model)
        {
            if (!await ValidateExerciseFormModelAsync(model))
            {
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            try
            {
                string adminUserId = GetCurrentUserId()!;
                await exerciseService.CreateExerciseAsync(model, adminUserId);

                TempData["SuccessMessage"] = "Exercise created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while creating exercise from admin panel.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the exercise. Please try again later.");

                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ExerciseFormModel? model = await exerciseService.GetExerciseForEditByAdminAsync(id);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Exercise was not found.";
                return RedirectToAction(nameof(Index));
            }

            await PopulateExerciseFormCollectionsAsync(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ExerciseFormModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!await ValidateExerciseFormModelAsync(model))
            {
                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }

            try
            {
                bool isEdited = await exerciseService.EditExerciseByAdminAsync(id, model);
                if (!isEdited)
                {
                    TempData["ErrorMessage"] = "Exercise was not found.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["SuccessMessage"] = "Exercise updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while editing exercise with id {ExerciseId} from admin panel.", id);
                ModelState.AddModelError(string.Empty, "An error occurred while editing the exercise. Please try again later.");

                await PopulateExerciseFormCollectionsAsync(model);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            ExerciseDeleteViewModel? model = await exerciseService.GetExerciseForDeleteByAdminAsync(id);

            if (model == null)
            {
                TempData["ErrorMessage"] = "Exercise was not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                bool isDeleted = await exerciseService.DeleteExerciseByAdminAsync(id);
                if (!isDeleted)
                {
                    TempData["ErrorMessage"] = "Exercise was not found.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["SuccessMessage"] = "Exercise deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred while deleting exercise with id {ExerciseId} from admin panel.", id);
                TempData["ErrorMessage"] = "An error occurred while deleting the exercise. Please try again later.";

                return RedirectToAction(nameof(Index));
            }
        }

        private async Task<bool> ValidateExerciseFormModelAsync(ExerciseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            bool muscleGroupExists = await muscleGroupService.ExistsByIdAsync(model.MuscleGroupId);
            if (!muscleGroupExists)
            {
                ModelState.AddModelError(nameof(model.MuscleGroupId), "Selected muscle group does not exist.");
            }

            bool equipmentExists = await equipmentService.ExistsByIdAsync(model.EquipmentId);
            if (!equipmentExists)
            {
                ModelState.AddModelError(nameof(model.EquipmentId), "Selected equipment does not exist.");
            }

            return ModelState.IsValid;
        }

        private async Task PopulateExerciseFormCollectionsAsync(ExerciseFormModel model)
        {
            IEnumerable<EquipmentViewModel> equipment = await equipmentService.GetAllEquipmentAsync();
            IEnumerable<MuscleGroupViewModel> muscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();

            model.Equipment = equipment;
            model.MuscleGroups = muscleGroups;
        }

        private async Task PopulateExerciseQueryCollectionsAsync(AllExercisesQueryModel model)
        {
            IEnumerable<EquipmentViewModel> equipment = await equipmentService.GetAllEquipmentAsync();
            IEnumerable<MuscleGroupViewModel> muscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();

            model.Equipment = equipment;
            model.MuscleGroups = muscleGroups;
        }
    }
}
