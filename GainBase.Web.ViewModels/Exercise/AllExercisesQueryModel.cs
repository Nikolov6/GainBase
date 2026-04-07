using System.ComponentModel.DataAnnotations;
using GainBase.Web.ViewModels.Equipment;
using GainBase.Web.ViewModels.MuscleGroup;

namespace GainBase.Web.ViewModels.Exercise
{
    public class AllExercisesQueryModel
    {
        private const int DefaultExercisesPerPage = 9;

        public int? MuscleGroupId { get; set; }
        public int? EquipmentId { get; set; }

        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; } = 1;

        public int ExercisesPerPage { get; } = DefaultExercisesPerPage;

        public int TotalExercises { get; set; }

        public int TotalPages
            => (int)Math.Ceiling((double)TotalExercises / ExercisesPerPage);

        public IEnumerable<MuscleGroupViewModel> MuscleGroups { get; set; }
            = new HashSet<MuscleGroupViewModel>();

        public IEnumerable<EquipmentViewModel> Equipment { get; set; }
            = new HashSet<EquipmentViewModel>();

        public IEnumerable<ExerciseIndexViewModel> Exercises { get; set; }
            = new HashSet<ExerciseIndexViewModel>();
    }
}