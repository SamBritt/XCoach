using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class Athlete
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Grade { get; set; }
        public int MPW { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public virtual ICollection<AthleteRace> AthleteRaces { get; set; }
        public virtual ICollection<AthleteWorkout> AthleteWorkouts { get; set; }
    }
}
