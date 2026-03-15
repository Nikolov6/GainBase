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
            IEnumerable<EquipmentViewModel> equipment = await equipmentService.GetAllEquipmentAsync();
            IEnumerable<MuscleGroupViewModel> muscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();

            ExerciseFormModel model = new ExerciseFormModel
            {
                Equipment = equipment,
                MuscleGroups = muscleGroups
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ExerciseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MuscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();
                model.Equipment = await equipmentService.GetAllEquipmentAsync();
                return View(model);
            }

            bool muscleGroupExists = await muscleGroupService.ExistsByIdAsync(model.MuscleGroupId);
            if(!muscleGroupExists)
            {
                ModelState.AddModelError(nameof(model.MuscleGroupId), "Selected muscle group does not exist.");
                model.MuscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();
                model.Equipment = await equipmentService.GetAllEquipmentAsync();
                return View(model);
            }

            bool equipmentExists = await equipmentService.ExistsByIdAsync(model.EquipmentId);
            if(!equipmentExists)
            {
                ModelState.AddModelError(nameof(model.EquipmentId), "Selected equipment does not exist.");
                model.MuscleGroups = await muscleGroupService.GetAllMuscleGroupsAsync();
                model.Equipment = await equipmentService.GetAllEquipmentAsync();
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
                this.logger.LogError(e, "An error occurred while creating an exercise.");
                
                ModelState.AddModelError(string.Empty, "An error occurred while creating the exercise. Please try again later.");

                return View(model);
            }
        }
    }
}