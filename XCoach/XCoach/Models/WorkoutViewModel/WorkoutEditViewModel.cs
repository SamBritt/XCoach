using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XCoach.Models.WorkoutViewModel
{
    public class WorkoutEditViewModel
    {
        public Workout Workout { get; set; }
        public List<WorkoutType> WorkoutTypes { get; set; }
        public List<SelectListItem> TypesToSelect
        {
            get
            {
                if (WorkoutTypes == null)
                {
                    return null;
                }
                var types = WorkoutTypes.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                }).ToList();
                types.Insert(0, new SelectListItem("Select Workout Type", "Add WorkoutType"));

                return types;
            }
        }
    }
}
