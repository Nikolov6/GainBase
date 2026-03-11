using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainBase.GCommon
{
    public static class EntityValidation
    {
        // Exercise
        public const int ExerciseNameMinLength = 3;
        public const int ExerciseNameMaxLength = 50;
        public const int ExerciseDescriptionMinLength = 10;
        public const int ExerciseDescriptionMaxLength = 1000;
        public const int ExerciseInstructionsMinLength = 10;
        public const int ExerciseInstructionsMaxLength = 2000;

        // Equipment
        public const int EquipmentNameMinLength = 3;
        public const int EquipmentNameMaxLength = 50;

        // MuscleGroup
        public const int MuscleGroupNameMinLength = 3;
        public const int MuscleGroupNameMaxLength = 50;

    }
}
