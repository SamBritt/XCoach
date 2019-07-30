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
    public class WorkoutTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutTypes.ToListAsync());
        }

        // GET: WorkoutTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutType = await _context.WorkoutTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutType == null)
            {
                return NotFound();
            }

            return View(workoutType);
        }

        // GET: WorkoutTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] WorkoutType workoutType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutType);
        }

        // GET: WorkoutTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutType = await _context.WorkoutTypes.FindAsync(id);
            if (workoutType == null)
            {
                return NotFound();
            }
            return View(workoutType);
        }

        // POST: WorkoutTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] WorkoutType workoutType)
        {
            if (id != workoutType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutTypeExists(workoutType.Id))
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
            return View(workoutType);
        }

        // GET: WorkoutTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutType = await _context.WorkoutTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutType == null)
            {
                return NotFound();
            }

            return View(workoutType);
        }

        // POST: WorkoutTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutType = await _context.WorkoutTypes.FindAsync(id);
            _context.WorkoutTypes.Remove(workoutType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutTypeExists(int id)
        {
            return _context.WorkoutTypes.Any(e => e.Id == id);
        }
    }
}
