using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models.AthleteViewModel
{
    public class AthleteDetailsViewModel
    {
        public Athlete Athlete { get; set; }
        public List<AthleteWorkout> AthleteWorkouts { get; set; }
        public List<AthleteWorkout> UpComingWorkouts
        {
            get
            {
                DateTime now = DateTime.Now;
                return AthleteWorkouts.Select(a => a).Where(a => a.WorkoutDate > now).ToList();
            }
        }
        
        public List<Dictionary<int, TimeSpan>> AthleteBestTimes { get; set; }

        
    }
}
