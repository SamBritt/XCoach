using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XCoach.Data;
using XCoach.Models;

namespace XCoach.Controllers
{
    public class AthleteWorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AthleteWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AthleteWorkouts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AthleteWorkouts.Include(a => a.Athlete)
                                                               .Include(a => a.Workout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AthleteWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteWorkout = await _context.AthleteWorkouts
                .Include(a => a.Athlete)
                .Include(a => a.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (athleteWorkout == null)
            {
                return NotFound();
            }

            return View(athleteWorkout);
        }

        // GET: AthleteWorkouts/Create
        public IActionResult Create()
        {
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName");
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Description");
            return View();
        }

        // POST: AthleteWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AthleteId,WorkoutId,Distance,Pace,Repetition,WorkoutDate")] AthleteWorkout athleteWorkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(athleteWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteWorkout.AthleteId);
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Description", athleteWorkout.WorkoutId);
            return View(athleteWorkout);
        }

        // GET: AthleteWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteWorkout = await _context.AthleteWorkouts.FindAsync(id);
            if (athleteWorkout == null)
            {
                return NotFound();
            }
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteWorkout.AthleteId);
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Description", athleteWorkout.WorkoutId);
            return View(athleteWorkout);
        }

        // POST: AthleteWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AthleteId,WorkoutId,Distance,Pace,Repetition,WorkoutDate")] AthleteWorkout athleteWorkout)
        {
            if (id != athleteWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(athleteWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteWorkoutExists(athleteWorkout.Id))
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
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteWorkout.AthleteId);
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Description", athleteWorkout.WorkoutId);
            return View(athleteWorkout);
        }

        // GET: AthleteWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteWorkout = await _context.AthleteWorkouts
                .Include(a => a.Athlete)
                .Include(a => a.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (athleteWorkout == null)
            {
                return NotFound();
            }

            return View(athleteWorkout);
        }

        // POST: AthleteWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athleteWorkout = await _context.AthleteWorkouts.FindAsync(id);
            _context.AthleteWorkouts.Remove(athleteWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthleteWorkoutExists(int id)
        {
            return _context.AthleteWorkouts.Any(e => e.Id == id);
        }
    }
}
