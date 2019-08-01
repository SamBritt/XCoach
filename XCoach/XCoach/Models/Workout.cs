using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public int WorkoutTypeId { get; set; }
        public WorkoutType WorkoutType { get; set; }

    }
}
