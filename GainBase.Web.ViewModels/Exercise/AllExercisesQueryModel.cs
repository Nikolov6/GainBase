using GainBase.Web.ViewModels.Equipment;
using GainBase.Web.ViewModels.MuscleGroup;

namespace GainBase.Web.ViewModels.Exercise
{
    public class AllExercisesQueryModel
    {
        public int? MuscleGroupId { get; set; }
        public int? EquipmentId { get; set; }

        public IEnumerable<MuscleGroupViewModel> MuscleGroups { get; set; }
            = new HashSet<MuscleGroupViewModel>();

        public IEnumerable<EquipmentViewModel> Equipment { get; set; }
            = new HashSet<EquipmentViewModel>();

        public IEnumerable<ExerciseIndexViewModel> Exercises { get; set; }
            = new HashSet<ExerciseIndexViewModel>();
    }
}