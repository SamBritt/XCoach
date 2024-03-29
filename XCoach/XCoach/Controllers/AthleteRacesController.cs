﻿using System;
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
    public class AthleteRacesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AthleteRacesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: AthleteRaces
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationDbContext = _context.AthleteRaces.Include(a => a.Athlete)
                                                            .Include(a => a.Race)
                                                            .Where(a => a.Athlete.UserId == currentUser.Id)
                                                            .Where(a => a.Race.UserId == currentUser.Id);
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
        public async Task<IActionResult> Create()
        {
            var currentUser = await GetCurrentUserAsync();
            ViewData["AthleteId"] = new SelectList(_context.Athletes.Where(a => a.UserId == currentUser.Id), "Id", "FirstName");

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
                return RedirectToAction("Index", "Races");
            }
            ViewData["AthleteId"] = new SelectList(_context.Athletes, "Id", "FirstName", athleteRace.AthleteId);
            return View(athleteRace);
        }

        // GET: AthleteRaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var currentUser = await GetCurrentUserAsync();

            if (id == null)
            {
                return NotFound();
            }

            var athleteRace = await _context.AthleteRaces.FindAsync(id);
            athleteRace.Athlete = await _context.Athletes.FirstOrDefaultAsync(a => a.Id == athleteRace.AthleteId);
            athleteRace.Race = await _context.Races.FirstOrDefaultAsync(r => r.Id == athleteRace.RaceId);
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
        public async Task<IActionResult> Edit(int id, AthleteRace athleteRace)
        {
          
            athleteRace.Athlete = await _context.Athletes.FirstOrDefaultAsync(a => a.Id == athleteRace.AthleteId);
            athleteRace.Race = await _context.Races.FirstOrDefaultAsync(r => r.Id == athleteRace.RaceId);
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
                return RedirectToAction("Index", "Races");
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
