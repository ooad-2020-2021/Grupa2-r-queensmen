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
    public class VodaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;

        public VodaController(ApplicationDbContext context, UserManager<RegistrovaniKorisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Voda
        public async Task<IActionResult> Index(string datumString)
        {
            DateTime datum = DateTime.ParseExact(datumString, "d_M_yyyy", null);
            var vodaVecPostoji = await _context.KolicineVode.FirstOrDefaultAsync(v => v.Datum == datum);
            if (vodaVecPostoji == null)
            {
                ViewBag.voda = 0;
                ViewBag.postoji = false;
                ViewBag.id = null;
            }
            else
            {
                ViewBag.voda = vodaVecPostoji.Kolicina;
                ViewBag.postoji = true;
                ViewBag.id = vodaVecPostoji.Id;
            }
            ViewBag.datum = DajDatumZaPrikaz(datum);
            ViewBag.datumFull = datum;
            var korisnik = await _userManager.GetUserAsync(User);
            return View(await _context.KolicineVode.Where(v => v.Korisnik.Id == korisnik.Id).ToListAsync());
        }

        // POST: Voda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Kolicina")] Voda voda)
        {
            if (ModelState.IsValid)
            {
                voda.Id = Guid.NewGuid();
                voda.Korisnik = await _userManager.GetUserAsync(User);
                _context.Add(voda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(voda.Datum) });
            }
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
        }

        // POST: Voda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Datum,Kolicina")] Voda voda)
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
                return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(voda.Datum) });
            }
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
        }

        private bool VodaExists(Guid id)
        {
            return _context.KolicineVode.Any(v => v.Id == id);
        }

        private string DajDatumZaParametra(DateTime datum)
        {
            return datum.ToString("d_M_yyyy");
        }

        private string DajDatumZaPrikaz(DateTime datum)
        {
            return datum.ToString("d.M.yyyy");
        }
    }
}
