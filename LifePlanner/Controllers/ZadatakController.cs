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
    public class ZadatakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZadatakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zadatak
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zadaci.Include(z => z.Korisnik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zadatak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadatak = await _context.Zadaci
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadatak == null)
            {
                return NotFound();
            }

            return View(zadatak);
        }

        // GET: Zadatak/Create
        public IActionResult Create()
        {
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email");
            return View();
        }

        // POST: Zadatak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Datum,KorisnikID")] Zadatak zadatak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zadatak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email", zadatak.KorisnikID);
            return View(zadatak);
        }

        // GET: Zadatak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadatak = await _context.Zadaci.FindAsync(id);
            if (zadatak == null)
            {
                return NotFound();
            }
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email", zadatak.KorisnikID);
            return View(zadatak);
        }

        // POST: Zadatak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Datum,KorisnikID")] Zadatak zadatak)
        {
            if (id != zadatak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zadatak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZadatakExists(zadatak.Id))
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
            ViewData["KorisnikID"] = new SelectList(_context.RegistrovaniKorisnici, "Id", "Email", zadatak.KorisnikID);
            return View(zadatak);
        }

        // GET: Zadatak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadatak = await _context.Zadaci
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zadatak == null)
            {
                return NotFound();
            }

            return View(zadatak);
        }

        // POST: Zadatak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zadatak = await _context.Zadaci.FindAsync(id);
            _context.Zadaci.Remove(zadatak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZadatakExists(int id)
        {
            return _context.Zadaci.Any(e => e.Id == id);
        }
    }
}
