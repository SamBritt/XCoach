using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public virtual ICollection<Race> Races { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}