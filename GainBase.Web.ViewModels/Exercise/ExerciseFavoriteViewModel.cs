using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainBase.Web.ViewModels.Exercise
{
    public class ExerciseFavoriteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string MuscleGroupName { get; set; } = null!;
        public string EquipmentName { get; set; } = null!;
        public string SavedAt { get; set; } = null!;
    }
}
