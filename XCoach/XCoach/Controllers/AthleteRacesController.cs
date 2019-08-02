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
    public class AthleteRacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AthleteRacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AthleteRaces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AthleteRaces.Include(a => a.Athlete).Include(a => a.Race);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AthleteRaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteRace = await _context.AthleteRaces
                .Include(a => a.Athlete)
                .Include(a => a.Race)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (athleteRace == null)
            {
                return NotFound();
            }

            return View(athleteRace);
        }

        // GET: AthleteRaces/Create
        public IActionResult Create()
        {
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName");
            //ViewData["RaceId"] = new SelectList(_context.Races, "Id", "EventName");
            return View();
        }

        // POST: AthleteRaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AthleteId,ProjectedTime,ActualTime")] AthleteRace athleteRace, [FromRoute]int id)
        {
            ModelState.Remove("RaceId");

            if (ModelState.IsValid)
            {
                athleteRace.RaceId = id;
                _context.Add(athleteRace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteRace.AthleteId);
            //ViewData["RaceId"] = new SelectList(_context.Races, "Id", "EventName", athleteRace.RaceId);
            return View(athleteRace);
        }

        // GET: AthleteRaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteRace = await _context.AthleteRaces.FindAsync(id);
            if (athleteRace == null)
            {
                return NotFound();
            }
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteRace.AthleteId);
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "EventName", athleteRace.RaceId);
            return View(athleteRace);
        }

        // POST: AthleteRaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AthleteId,RaceId,ProjectedTime,ActualTime")] AthleteRace athleteRace)
        {
            if (id != athleteRace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(athleteRace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteRaceExists(athleteRace.Id))
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
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteRace.AthleteId);
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "EventName", athleteRace.RaceId);
            return View(athleteRace);
        }

        // GET: AthleteRaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteRace = await _context.AthleteRaces
                .Include(a => a.Athlete)
                .Include(a => a.Race)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (athleteRace == null)
            {
                return NotFound();
            }

            return View(athleteRace);
        }

        // POST: AthleteRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athleteRace = await _context.AthleteRaces.FindAsync(id);
            _context.AthleteRaces.Remove(athleteRace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthleteRaceExists(int id)
        {
            return _context.AthleteRaces.Any(e => e.Id == id);
        }
    }
}
