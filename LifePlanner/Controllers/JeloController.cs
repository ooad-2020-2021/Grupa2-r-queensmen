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
    public class JeloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JeloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jelo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jela.ToListAsync());
        }

        // GET: Jelo/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await _context.Jela
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // GET: Jelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Kategorija,Sastojci")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                jelo.Id = Guid.NewGuid();
                _context.Add(jelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jelo);
        }

        // GET: Jelo/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await _context.Jela.FindAsync(id);
            if (jelo == null)
            {
                return NotFound();
            }
            return View(jelo);
        }

        // POST: Jelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Naziv,Kategorija,Sastojci")] Jelo jelo)
        {
            if (id != jelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JeloExists(jelo.Id))
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
            return View(jelo);
        }

        // GET: Jelo/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await _context.Jela
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // POST: Jelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jelo = await _context.Jela.FindAsync(id);
            _context.Jela.Remove(jelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JeloExists(Guid id)
        {
            return _context.Jela.Any(e => e.Id == id);
        }
    }
}
