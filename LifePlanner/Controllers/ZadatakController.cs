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

namespace LifePlanner.Controllers
{
    public class ZadatakController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;

        public ZadatakController(ApplicationDbContext context, UserManager<RegistrovaniKorisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Zadatak
        public async Task<IActionResult> Index(string datumString)
        {
            //dohvati sve taskove za taj dan i posalji ih na view
            DateTime datum = DateTime.ParseExact(datumString, "d_M_yyyy", null);
            var taskoviZaDan = await _context.Zadaci.Where(z => z.Datum == datum).ToListAsync();
            ViewBag.datum = datum;
            return View(taskoviZaDan);
        }

        // POST: Zadatak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Datum")] Zadatak zadatak)
        {
            if (ModelState.IsValid)
            {
                zadatak.Id = Guid.NewGuid();
                zadatak.Korisnik = await _userManager.GetUserAsync(User);
                _context.Add(zadatak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { datumString = zadatak.Datum.ToString("d_M_yyyy") });
            }
            return RedirectToAction(nameof(Index), new { datumString = DateTime.Now.ToString("d_M_yyyy") });
        }

        // POST: Zadatak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Naziv,Datum")] Zadatak zadatak)
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
                return RedirectToAction(nameof(Index), new { datumString = zadatak.Datum.ToString("d_M_yyyy") });
            }
            return RedirectToAction(nameof(Index), new { datumString = DateTime.Now.ToString("d_M_yyyy") });
        }

        // POST: Zadatak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var zadatak = await _context.Zadaci.FindAsync(id);
            _context.Zadaci.Remove(zadatak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { datumString = DateTime.Now.ToString("d_M_yyyy") });
        }

        private bool ZadatakExists(Guid id)
        {
            return _context.Zadaci.Any(e => e.Id == id);
        }
    }
}
