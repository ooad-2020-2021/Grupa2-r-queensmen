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

namespace LifePlanner
{
    public class TreningController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;

        public TreningController(ApplicationDbContext context, UserManager<RegistrovaniKorisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Trening
        public async Task<IActionResult> Index()
        {
            return View(await _context.Treninzi.ToListAsync());
        }

        // GET: Trening/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Treninzi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // GET: Trening/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trening/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Vjezbe")] Trening trening)
        {
            if (ModelState.IsValid)
            {
                trening.Id = Guid.NewGuid();
                RegistrovaniKorisnik trenutni = await _userManager.GetUserAsync(HttpContext.User);
                trening.Korisnik = trenutni;
                _context.Add(trening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trening);
        }

        // GET: Trening/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            return View(trening);
        }

        // POST: Trening/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Naziv,Vjezbe")] Trening trening)
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
            return View(trening);
        }

        // GET: Trening/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Treninzi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // POST: Trening/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trening = await _context.Treninzi.FindAsync(id);
            _context.Treninzi.Remove(trening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreningExists(Guid id)
        {
            return _context.Treninzi.Any(e => e.Id == id);
        }
    }
}
