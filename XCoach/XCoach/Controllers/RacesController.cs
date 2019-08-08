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

namespace XCoach.Controllers
{
    [Authorize]
    public class RacesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RacesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Races
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var athleteRaces = await _context.Races.Include(r => r.AthleteRaces).Where(r => r.UserId == currentUser.Id).ToListAsync();

            //return View(await _context.Races.ToListAsync());
            return View(athleteRaces);
        }

        // GET: Races/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var race = await _context.Races
                .Include(r => r.AthleteRaces)
                .ThenInclude(ar => ar.Athlete)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // GET: Races/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MeetName,Location,EventName,Distance,EventDate")] Race race)
        {
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                var CurrentUser = await GetCurrentUserAsync();
                race.User = CurrentUser;
                race.UserId = CurrentUser.Id;
                _context.Add(race);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(race);
        }

        // GET: Races/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetName,Location,EventName,Distance,EventDate")] Race race)
        {
            ModelState.Remove("UserId");

            var currentUser = await GetCurrentUserAsync();
            race.UserId = currentUser.Id;

            if (id != race.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(race);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExists(race.Id))
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
            return View(race);
        }

        // GET: Races/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var race = await _context.Races
                .Include(a => a.User)
                .Include(a => a.AthleteRaces)
                .ThenInclude(ar => ar.Athlete)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);

            //var race = await _context.Races
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await GetCurrentUserAsync();
            var userId = user.Id;
            var race = await _context.Races.FindAsync(id);
            var athleteRaces = _context.AthleteRaces;

            foreach (AthleteRace wo in athleteRaces)
            {
                if (wo.RaceId == race.Id && userId == race.UserId)
                {
                    athleteRaces.Remove(wo);
                }

            }
            if (userId == race.UserId)
            {
                _context.Races.Remove(race);
            }


            //var race = await _context.Races.FindAsync(id);
            //_context.Races.Remove(race);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.Id == id);
        }
    }
}
