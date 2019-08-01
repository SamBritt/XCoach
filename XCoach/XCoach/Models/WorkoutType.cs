using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models
{
    public class WorkoutType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string Name { get; set; }
    }
}
