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
            DateTime datum = DateTime.ParseExact(datumString, "dd_M_yyyy", null);
            var popijenaVodaNaDan = await _context.KolicineVode.FirstOrDefaultAsync(v => v.Datum == datum);
            if (popijenaVodaNaDan == null)
            {
                ViewBag.voda = 0;
            }
            else
            {
                ViewBag.voda = popijenaVodaNaDan.Kolicina;
            }            
            ViewBag.datum = datum.ToString("dd.M.yyyy");
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
                _context.Add(voda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voda);
        }

        // GET: Voda/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
                return RedirectToAction(nameof(Index));
            }
            return View(voda);
        }

        private bool VodaExists(Guid id)
        {
            return _context.KolicineVode.Any(v => v.Id == id);
        }
    }
}
