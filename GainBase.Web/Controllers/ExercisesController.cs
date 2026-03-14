using GainBase.Services.Core.Contracts;
using GainBase.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GainBase.Web.Controllers
{
    public class ExercisesController : BaseController
    {
        private readonly IExerciseService exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? currentUserId = GetCurrentUserId();
            IEnumerable<ExerciseIndexViewModel> exercises = await exerciseService.GetAllExercisesAsync(currentUserId);
            return View(exercises);
        }
    }
}
