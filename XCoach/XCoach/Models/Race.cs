using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [Display(Name = "Meet")]
        public string MeetName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Event")]
        public string EventName { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        public ICollection<AthleteRace> AthleteRaces { get; set; }
        
    }
}
