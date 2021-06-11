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
using LifePlanner.Utility;

namespace LifePlanner.Controllers
{
    public class ZadatakController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;
        private readonly List<string> savjeti = new List<string>
        {
            "No matter how busy you may think you are, you must find time for reading, or surrender yourself to self-chosen ignorance.",
            "The authority of those who teach is often an obstacle to those who want to learn.",
            "To acquire knowledge, one must study; but to acquire wisdom, one must observe."
        };

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
            var korisnik = await _userManager.GetUserAsync(User);
            List<Zadatak> taskoviZaDan = new List<Zadatak> { };
            
            if (korisnik == null)
            {
                taskoviZaDan = HttpContext.Session.GetObjectFromJson<List<Zadatak>>("NeRegZadaci");
                if (taskoviZaDan == null)
                {
                    taskoviZaDan = new List<Zadatak> { };
                }
            }
            else
            {
                taskoviZaDan = await _context.Zadaci.Where(z => z.Datum == datum && z.Korisnik == korisnik).ToListAsync();
            }

            string randomSavjet = savjeti[new Random().Next(savjeti.Count)];
            ViewBag.savjet = randomSavjet;
            ViewBag.datum = datum;

            var raspolozenje = await _context.Raspolozenja.FirstOrDefaultAsync(r => r.Datum == datum && r.Korisnik == korisnik);
            ViewBag.datum = datum;
            ViewBag.danasnjiDatum = DateTime.Today;
            if (raspolozenje != null)
            {
                ViewBag.raspolozenje = true;
                ViewBag.raspolozenjeId = raspolozenje.Id;
            }
            else
            {
                ViewBag.raspolozenje = false;
            }

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
                RegistrovaniKorisnik korisnik = await _userManager.GetUserAsync(User);

                //spasi u sesiju umjesto bazu
                if (korisnik == null)
                {
                    List<Zadatak> postojeciTaskovi = HttpContext.Session.GetObjectFromJson<List<Zadatak>>("NeRegZadaci");
                    if (postojeciTaskovi == null)
                    {
                        postojeciTaskovi = new List<Zadatak> { };
                    }
                    postojeciTaskovi.Add(zadatak);
                    HttpContext.Session.SetObjectAsJson("NeRegZadaci", postojeciTaskovi);
                    return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(zadatak.Datum) });
                }



                zadatak.Korisnik = korisnik;
                _context.Add(zadatak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(zadatak.Datum) });
            }
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
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
                return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(zadatak.Datum) });
            }
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
        }

        // POST: Zadatak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                List<Zadatak> postojeciTaskovi = HttpContext.Session.GetObjectFromJson<List<Zadatak>>("NeRegZadaci");
                Zadatak zadatak1 = postojeciTaskovi.FirstOrDefault(z => z.Id == id);
                postojeciTaskovi.Remove(zadatak1);
                HttpContext.Session.SetObjectAsJson("NeRegZadaci", postojeciTaskovi);
                return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(zadatak1.Datum) });
            }
            var zadatak = await _context.Zadaci.FindAsync(id);
            _context.Zadaci.Remove(zadatak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { datumString = DajDatumZaParametra(DateTime.Now) });
        }

        private bool ZadatakExists(Guid id)
        {
            return _context.Zadaci.Any(e => e.Id == id);
        }

        private string DajDatumZaParametra(DateTime datum)
        {
            return datum.ToString("d_M_yyyy");
        }
    }
}
