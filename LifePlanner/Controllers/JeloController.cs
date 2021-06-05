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
    public class JeloController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;

        public JeloController(ApplicationDbContext context, UserManager<RegistrovaniKorisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var korisnik = await _userManager.GetUserAsync(User);
            IEnumerable<Jelo> jelaKorisnika = await _context.Jela.Where(j => j.Korisnik.Id == korisnik.Id).ToListAsync();
            return View("JelaPoKategorijama", jelaKorisnika);
        }

        [HttpPost, ActionName("DodajUKategoriju")]
        [ValidateAntiForgeryToken]
        //moglo je sa id atributom
        public async Task<IActionResult> dodajJeloUKategoriju(int kategorija, Guid idJela)
        {
            KategorijaJela _kategorija = (KategorijaJela)kategorija;
            Jelo jelo = await _context.Jela.SingleOrDefaultAsync
                (j => j.Id == idJela);
            if(jelo == null)
            {
                return RedirectToAction("Index");
            }
            jelo.Kategorija = _kategorija;
            _context.Update(jelo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");        
        }

        // GET: Jelo
        [ActionName("SvaJela")]
        public async Task<IActionResult> IndexSvaJela()
        {
            var kor = await _userManager.GetUserAsync(User);
            string id = kor.Id;
            IEnumerable<Jelo> jelaOdKorisnika = await _context.Jela.Where(
                j => id == j.Korisnik.Id
            ).ToListAsync();

            return View("Index", jelaOdKorisnika);
        }

        // GET: Jelo/Details/5
        [ActionName("Details")]
        public async Task<IActionResult> Index(Guid? id)
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
        [ActionName("Create")]
        public IActionResult DodajJelo()
        {
            return View();
        }

        // POST: Jelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajJelo([Bind("Id,Naziv,Sastojci")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                jelo.Id = Guid.NewGuid();
                
                RegistrovaniKorisnik trenutni = await _userManager.GetUserAsync(User);
                jelo.Korisnik = trenutni;
                jelo.Sastojci = jelo.Sastojci.Where(s => s != null).ToList();

                _context.Add(jelo);
                await _context.SaveChangesAsync();
                return RedirectToAction("SvaJela");
            }
            return View(jelo);
        }

        // GET: Jelo/Edit/5
        [ActionName("Edit")]
        public async Task<IActionResult> UrediJelo(Guid? id)
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrediJelo(Guid id, [Bind("Id,Naziv,Sastojci")] Jelo jelo)
        {
            if (id != jelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    jelo.Sastojci = jelo.Sastojci.Where(s => s != null).ToList();
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
                return RedirectToAction("SvaJela");
            }
            return View(jelo);
        }

        // GET: Jelo/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> ObrisiJelo(Guid? id)
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
        public async Task<IActionResult> ObrisiJelo(Guid id)
        {
            var jelo = await _context.Jela.FindAsync(id);
            _context.Jela.Remove(jelo);
            await _context.SaveChangesAsync();
            return RedirectToAction("SvaJela");
        }

        private bool JeloExists(Guid id)
        {
            return _context.Jela.Any(e => e.Id == id);
        }
    }
}
