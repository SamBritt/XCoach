using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class AthleteRace
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AthleteId { get; set; }
        [Required]
        public int RaceId { get; set; }
        public Athlete Athlete { get; set; }
        public Race Race { get; set; }
        [Required]
        [Display(Name = "Projected Time")]
        public TimeSpan ProjectedTime { get; set; }
        [Display(Name = "Actual Time")]
        public TimeSpan? ActualTime { get; set; }
    }
}
