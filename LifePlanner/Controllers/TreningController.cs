using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifePlanner.Data;
using LifePlanner.Models;

namespace LifePlanner.Controllers
{
    public class TreningController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreningController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treninzi
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Treninzi.Include(t => t.Korisnik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Treninzi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Treninzi
                .Include(t => t.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // GET: Treninzi/Create
        public IActionResult Create()
        {
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email");
            return View();
        }

        // POST: Treninzi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Vjezbe,KorisnikID")] Trening trening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email", trening.KorisnikID);
            return View(trening);
        }

        // GET: Treninzi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Treninzi.FindAsync(id);
            if (trening == null)
            {
                return NotFound();
            }
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email", trening.KorisnikID);
            return View(trening);
        }

        // POST: Treninzi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Vjezbe,KorisnikID")] Trening trening)
        {
            if (id != trening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreningExists(trening.Id))
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
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email", trening.KorisnikID);
            return View(trening);
        }

        // GET: Treninzi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Treninzi
                .Include(t => t.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // POST: Treninzi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trening = await _context.Treninzi.FindAsync(id);
            _context.Treninzi.Remove(trening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreningExists(int id)
        {
            return _context.Treninzi.Any(e => e.Id == id);
        }
    }
}
