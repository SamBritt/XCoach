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
using XCoach.Models.AthleteViewModel;

namespace XCoach.Controllers
{

    [Authorize]
    public class AthletesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AthletesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Athletes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Athletes.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Athletes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var athlete = await _context.Athletes
                .Include(a => a.AthleteRaces)
                .Include(a => a.AthleteWorkouts)
                .ThenInclude(aw => aw.Workout)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (athlete == null)
            {
                return NotFound();
            }
            AthleteDetailsViewModel model = new AthleteDetailsViewModel
            {
                Athlete = athlete,
                AthleteWorkouts = await _context.AthleteWorkouts.Select(a => a).Where(a => a.AthleteId == id).ToListAsync(),

            };

            return View(model);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Athletes/Create
        public IActionResult Create()
        {
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, User, UserId,FirstName,LastName,Gender,Grade,MPW")] Athlete athlete)
        {
           //var user = await GetCurrentUserAsync();
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                var CurrentUser = await GetCurrentUserAsync();
                athlete.User = CurrentUser;
                athlete.UserId = CurrentUser.Id;
                _context.Add(athlete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", athlete.UserId);
            return View(athlete);
        }

        // GET: Athletes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes.FindAsync(id);
            if (athlete == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", athlete.UserId);
            return View(athlete);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FirstName,LastName,Gender,Grade,MPW")] Athlete athlete)
        {
            if (id != athlete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(athlete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteExists(athlete.Id))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", athlete.UserId);
            return View(athlete);
        }

        // GET: Athletes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (athlete == null)
            {
                return NotFound();
            }

            return View(athlete);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);
            _context.Athletes.Remove(athlete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthleteExists(int id)
        {
            return _context.Athletes.Any(e => e.Id == id);
        }
    }
}
