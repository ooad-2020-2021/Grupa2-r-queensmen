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
    public class RaspolozenjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaspolozenjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Raspolozenje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Raspolozenja.ToListAsync());
        }

        // GET: Raspolozenje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspolozenje = await _context.Raspolozenja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raspolozenje == null)
            {
                return NotFound();
            }

            return View(raspolozenje);
        }

        // GET: Raspolozenje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Raspolozenje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,TipRaspolozenja,KorisnikId")] Raspolozenje raspolozenje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raspolozenje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raspolozenje);
        }

        // GET: Raspolozenje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspolozenje = await _context.Raspolozenja.FindAsync(id);
            if (raspolozenje == null)
            {
                return NotFound();
            }
            return View(raspolozenje);
        }

        // POST: Raspolozenje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,TipRaspolozenja,KorisnikId")] Raspolozenje raspolozenje)
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
                return RedirectToAction(nameof(Index));
            }
            return View(raspolozenje);
        }

        // GET: Raspolozenje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspolozenje = await _context.Raspolozenja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raspolozenje == null)
            {
                return NotFound();
            }

            return View(raspolozenje);
        }

        // POST: Raspolozenje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raspolozenje = await _context.Raspolozenja.FindAsync(id);
            _context.Raspolozenja.Remove(raspolozenje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaspolozenjeExists(int id)
        {
            return _context.Raspolozenja.Any(e => e.Id == id);
        }
    }
}
