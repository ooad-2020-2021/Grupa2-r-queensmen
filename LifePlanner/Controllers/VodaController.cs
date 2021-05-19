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
    public class VodaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VodaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voda
        public async Task<IActionResult> Index()
        {
            return View(await _context.KolicineVode.ToListAsync());
        }

        // GET: Voda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voda = await _context.KolicineVode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voda == null)
            {
                return NotFound();
            }

            return View(voda);
        }

        // GET: Voda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Kolicina,KorisnikId")] Voda voda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voda);
        }

        // GET: Voda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voda = await _context.KolicineVode.FindAsync(id);
            if (voda == null)
            {
                return NotFound();
            }
            return View(voda);
        }

        // POST: Voda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Kolicina,KorisnikId")] Voda voda)
        {
            if (id != voda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VodaExists(voda.Id))
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
            return View(voda);
        }

        // GET: Voda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voda = await _context.KolicineVode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voda == null)
            {
                return NotFound();
            }

            return View(voda);
        }

        // POST: Voda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voda = await _context.KolicineVode.FindAsync(id);
            _context.KolicineVode.Remove(voda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VodaExists(int id)
        {
            return _context.KolicineVode.Any(e => e.Id == id);
        }
    }
}
