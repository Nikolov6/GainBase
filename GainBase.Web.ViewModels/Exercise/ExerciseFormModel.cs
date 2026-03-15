using GainBase.Web.ViewModels.Equipment;
using GainBase.Web.ViewModels.MuscleGroup;
using System.ComponentModel.DataAnnotations;
using static GainBase.GCommon.EntityValidation;

namespace GainBase.Web.ViewModels.Exercise
{
    public class ExerciseFormModel
    {
        [Required]
        [StringLength(ExerciseNameMaxLength, MinimumLength = ExerciseNameMinLength)]
        public string Name { get; set; } = null!;

        [StringLength(ExerciseDescriptionMaxLength, MinimumLength = ExerciseDescriptionMinLength)]
        public string? Description { get; set; }

        [Required]
        public int MuscleGroupId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        [StringLength(ExerciseInstructionsMaxLength, MinimumLength = ExerciseInstructionsMinLength)]
        public string Instructions { get; set; } = null!;

        public IEnumerable<MuscleGroupViewModel> MuscleGroups { get; set; }
            = new List<MuscleGroupViewModel>();
        public IEnumerable<EquipmentViewModel> Equipment { get; set; }
            = new List<EquipmentViewModel>();
    }
}