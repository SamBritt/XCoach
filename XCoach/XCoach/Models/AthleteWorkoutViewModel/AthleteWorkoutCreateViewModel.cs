using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models.AthleteWorkoutViewModel
{
    public class AthleteWorkoutCreateViewModel
    {
        public Workout Workout { get; set; }
        public AthleteWorkout AthleteWorkouts { get; set; }
        public List<int> SelectedAthletes { get; set;}
        public List<Athlete> AvailableAthletes { get; set; }
        public List<SelectListItem> AvailableAthletesSelectList
        {
            get
            {
                if(AvailableAthletes == null)
                {
                    return null;
                }
                return AvailableAthletes
                    .Select(a => new SelectListItem(a.FirstName, a.Id.ToString()))
                    .ToList();
            }
        }
    }
}
