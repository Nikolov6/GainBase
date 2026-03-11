using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GainBase.Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(ExerciseId))]
    public class UserExercise
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public Guid ExerciseId { get; set; }

        public DateTime SavedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [ForeignKey(nameof(ExerciseId))]
        public virtual Exercise Exercise { get; set; } = null!;
    }
}
