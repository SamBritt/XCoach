using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XCoach.Data;
using XCoach.Models;
using XCoach.Models.WorkoutViewModel;

namespace XCoach.Controllers
{
    [Authorize]
    public class WorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public WorkoutsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Workouts
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var workouts = await _context.Workouts
                .Include(w => w.WorkoutType)
                .Where(w => w.WorkoutType.Id == w.WorkoutTypeId)
                .Where(w => w.UserId == currentUser.Id)
                .ToListAsync() ;

            return View(workouts);
        }

        // GET: Workouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workouts
                .Include(w => w.WorkoutType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // GET: Workouts/Create

        public async Task<IActionResult> Create()
        {
            var CurrentUser = await GetCurrentUserAsync();
            var viewModel = new WorkoutCreateViewModel
            {
                WorkoutTypes = await _context.WorkoutTypes.ToListAsync()
            };
            List<WorkoutType> typesToAdd = GetAllWorkoutTypes();
            viewModel.WorkoutTypes = typesToAdd;
            return View(viewModel);
        }
        public List<WorkoutType> GetAllWorkoutTypes()
        {
            var types = _context.WorkoutTypes.ToList();
            return types;
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutCreateViewModel viewModel)
        {
            ModelState.Remove("Workout.UserId");
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                var workout = viewModel.Workout;
                workout.User = currentUser;
                workout.UserId = currentUser.Id;
                
                _context.Add(workout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.WorkoutTypes = await _context.WorkoutTypes.ToListAsync();
            return View(viewModel);
        }

        // GET: Workouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var CurrentUser = await GetCurrentUserAsync();
            var viewModel = new WorkoutEditViewModel
            {
                WorkoutTypes = await _context.WorkoutTypes.ToListAsync()
            };

            List<WorkoutType> typesToAdd = GetAllWorkoutTypes();
            viewModel.WorkoutTypes = typesToAdd;
            var workout = await _context.Workouts.FindAsync(id);
            viewModel.Workout = workout;
            if (id == null)
            {
                return NotFound();
            } 
            if (workout == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WorkoutEditViewModel viewModel, int id, [Bind("Id,Title,Description,WorkoutTypeId")] Workout workout)
        {

            ModelState.Remove("Workout.UserId");

            var currentUser = await GetCurrentUserAsync();
            workout = viewModel.Workout;
            workout.UserId = currentUser.Id;

            if (id != workout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutExists(workout.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            viewModel.WorkoutTypes = await _context.WorkoutTypes.ToListAsync();
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.Id == id);
        }
    }
}
