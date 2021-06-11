using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifePlanner.Data;
using LifePlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LifePlanner.Controllers
{
    [Authorize]
    public class MoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;

        public MoodController(ApplicationDbContext context, UserManager<RegistrovaniKorisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Mood
        public async Task<IActionResult> Index(string datumString)
        {
            DateTime datum = DateTime.ParseExact(datumString, "d_M_yyyy", null);
            var korisnik = await _userManager.GetUserAsync(User);
            var moodVecPostoji = await _context.Raspolozenja.FirstOrDefaultAsync(r => r.Datum == datum && r.Korisnik == korisnik);
            ViewBag.datum = datum.ToString("d.M.yyyy");
            ViewBag.datumFull = datum;
            return View(moodVecPostoji);
        }


        // POST: Mood/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,TipRaspolozenja")] Raspolozenje raspolozenje)
        {
            if (ModelState.IsValid)
            {
                raspolozenje.Id = Guid.NewGuid();
                raspolozenje.Korisnik = await _userManager.GetUserAsync(User);
                _context.Add(raspolozenje);
                await _context.SaveChangesAsync();
                string referer = Request.Headers["Referer"].ToString();

                //posto se dodavanje novog raspolozenja odvija i iz Zadatak kontrolera i odavde, moramo uraditi redirect na referera, a ne striktno na index Mood-a
                return Redirect(referer);
                //return RedirectToAction(nameof(Index), new { datumString = raspolozenje.Datum.ToString("d_M_yyyy") });
            }
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
        }

        // POST: Mood/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Datum,TipRaspolozenja")] Raspolozenje raspolozenje)
        {
            if (id != raspolozenje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raspolozenje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaspolozenjeExists(raspolozenje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                string referer = Request.Headers["Referer"].ToString();
                //posto se dodavanje novog raspolozenja odvija i iz Zadatak kontrolera i odavde, moramo uraditi redirect na referera, a ne striktno na index Mood-a
                return Redirect(referer);
                //return RedirectToAction(nameof(Index), new { datumString = raspolozenje.Datum.ToString("d_M_yyyy") });
            }
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
        }

        private bool RaspolozenjeExists(Guid id)
        {
            return _context.Raspolozenja.Any(e => e.Id == id);
        }

        private string DajDatumZaParametra(DateTime datum)
        {
            return datum.ToString("d_M_yyyy");
        }
    }
}
