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
using LifePlanner.Utility.Strategy;

namespace LifePlanner.Controllers
{
    [Authorize]
    public class TreningController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegistrovaniKorisnik> _userManager;
        //prilikom svakog requesta kontroler se instancira nanovo
        //zato ovo mora biti staticki atribut 
        private static SortStrategy<Trening> _sortTreninga = new BrojVjezbiSort();

        public TreningController(ApplicationDbContext context, UserManager<RegistrovaniKorisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Trening
        public async Task<IActionResult> Index()
        {
            var kor = await _userManager.GetUserAsync(User);
            string id = kor.Id;
            IEnumerable<Trening> treninziOdKorisnika = await _context.Treninzi.Where(
                t => id == t.Korisnik.Id
            ).ToListAsync();
            return View(treninziOdKorisnika);
        }

        // GET: Trening/Details/5
        [ActionName("Opis")]
        public async Task<IActionResult> Opis(Guid? id)
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
        [ActionName("Kreiraj")]
        public IActionResult KreirajTrening()
        {
            return View();
        }

        // POST: Trening/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Kreiraj")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KreirajTrening([Bind("Id,Naziv,Vjezbe")] Trening trening)
        {
            if (ModelState.IsValid)
            {
                trening.Id = Guid.NewGuid();
                RegistrovaniKorisnik trenutni = await _userManager.GetUserAsync(HttpContext.User);
                trening.Korisnik = trenutni;
                if (trening.Vjezbe == null)
                {
                    trening.Vjezbe = new List<string>();
                }
                else
                {
                    trening.Vjezbe = trening.Vjezbe.Where(v => v != null).ToList();
                }
                _context.Add(trening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trening);
        }

        // GET: Trening/Edit/5
        [ActionName("Uredi")]
        public async Task<IActionResult> UrediTrening(Guid? id)
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
        [HttpPost, ActionName("Uredi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrediTrening(Guid id, [Bind("Id,Naziv,Vjezbe")] Trening trening)
        {
            if (id != trening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trening.Vjezbe = trening.Vjezbe.Where(v => v != null).ToList();
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
        [ActionName("Obrisi")]
        public async Task<IActionResult> ObrisiTrening(Guid? id)
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
        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ObrisiTrening(Guid id)
        {
            var trening = await _context.Treninzi.FindAsync(id);
            _context.Treninzi.Remove(trening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //OVO JE U SLUCAJU DA IMPLEMENTUJEMO DUGME NA FRONTENDU!!!!
        [HttpPost, ActionName("SetSortStrategy")]
        [ValidateAntiForgeryToken]
        public IActionResult PostaviSortStrategy(string strategyIme)
        {
            //moramo koristiti reflection
            //paziti na assembly
            //https://stackoverflow.com/questions/48527525/get-executing-assembly-name-in-net-core/50877287
            //https://stackoverflow.com/questions/3512319/resolve-type-from-class-name-in-a-different-assembly
            try
            {
                Type tip = Type.GetType("LifePlanner.Utility.Strategy." + strategyIme + ", " + System.Reflection.Assembly.GetExecutingAssembly().ToString(), true);
                Object o = Activator.CreateInstance(tip);
                SortStrategy<Trening> noviStrategy = (SortStrategy<Trening>)o;
                _sortTreninga = noviStrategy;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        //OVO JE DA MOZEMO LAHKO IZ KODA MIJENJATI BEZ POTREBE ZA DUGMETOM NA FRONTENDU
        public void PostaviSortStrategyBezView(string strategyIme)
        {
            //moramo koristiti reflection
            //paziti na assembly
            //https://stackoverflow.com/questions/48527525/get-executing-assembly-name-in-net-core/50877287
            //https://stackoverflow.com/questions/3512319/resolve-type-from-class-name-in-a-different-assembly
            try
            {
                Type tip = Type.GetType("LifePlanner.Utility.Strategy." + strategyIme + ", " + System.Reflection.Assembly.GetExecutingAssembly().ToString(), true);
                Object o = Activator.CreateInstance(tip);
                SortStrategy<Trening> noviStrategy = (SortStrategy<Trening>)o;
                _sortTreninga = noviStrategy;
                return;
            }
            catch (Exception e)
            {
                return;
            }
        }

        public async Task<IActionResult> Sort()
        {
            if (_sortTreninga.GetType() == typeof(BrojVjezbiSort))
            {
                PostaviSortStrategyBezView("NazivTreningaSort");
            }
            else
            {
                PostaviSortStrategyBezView("BrojVjezbiSort");
            }
            var kor = await _userManager.GetUserAsync(User);
            string id = kor.Id;
            IList<Trening> treninziOdKorisnika = await _context.Treninzi.Where(
                t => id == t.Korisnik.Id
            ).ToListAsync();
            var treninziZaView = _sortTreninga.execute(treninziOdKorisnika);
            return View("Index", treninziZaView);
        }

        private bool TreningExists(Guid id)
        {
            return _context.Treninzi.Any(e => e.Id == id);
        }
    }
}
