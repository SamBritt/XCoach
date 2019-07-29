using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class AthleteWorkout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AthleteId { get; set; }
        [Required]
        public int WorkoutId { get; set; }
        public Athlete Athlete {get;set;}
        public Workout Workout { get; set; }
        public int Distance { get; set; }
        public TimeSpan Pace { get; set; }
        public int Repetition { get; set; }
        [Required]
        public DateTime WorkoutDate { get; set; }
    }
}
