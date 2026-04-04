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

        // Workout
        public const int WorkoutNameMinLength = 3;
        public const int WorkoutNameMaxLength = 60;
        public const int WorkoutDescriptionMinLength = 10;
        public const int WorkoutDescriptionMaxLength = 600;

        // GymSession
        public const int GymSessionDurationMinMinutes = 1;
        public const int GymSessionDurationMaxMinutes = 600;
        public const int GymSessionNoteMaxLength = 1200;

        // GymSessionExerciseLog
        public const int GymSessionSetsMinValue = 1;
        public const int GymSessionSetsMaxValue = 30;
        public const int GymSessionRepsMinValue = 1;
        public const int GymSessionRepsMaxValue = 200;
    }
}
