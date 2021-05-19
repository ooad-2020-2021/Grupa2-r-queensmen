using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class RegistrovaniKorisnik : IdentityUser, IVoda, IZadatak, IJelo, IRaspolozenje, ITrening
    {
        public RegistrovaniKorisnik() : base()
        {

        }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [NotMapped]
        public List<Zadatak> Zadaci { get; set; }

        [NotMapped]
        public List<Jelo> Jela { get; set; }

        [NotMapped]
        public List<Trening> Treninzi { get; set; }

        [NotMapped]
        public List<Voda> PopijenaVoda { get; set; }

        [NotMapped]
        public List<Raspolozenje> Raspolozenja { get; set; }

        public void DodajJelo(Jelo jelo)
        {
            Jela.Add(jelo);
        }

        public void DodajRaspolozenje(Raspolozenje raspolozenje)
        {
            Raspolozenja.Add(raspolozenje);
        }

        public void DodajZadatak(Zadatak task)
        {
            Zadaci.Add(task);
        }

        public void DodajTrening(Trening trening)
        {
            Treninzi.Add(trening);
        }

        public void DodajVodu(Voda voda)
        {
            PopijenaVoda.Add(voda);
        }

        public void ObrisiJelo(int id)
        {
            var jeloZaBrisanje = Jela.SingleOrDefault<Jelo>(j => j.Id == id);
            if (jeloZaBrisanje == null) return;
            Jela.Remove(jeloZaBrisanje);
        }

        public void ObrisiZadatak(int id)
        {
            var taskZaBrisanje = Zadaci.SingleOrDefault<Zadatak>(j => j.Id == id);
            if (taskZaBrisanje == null) return;
            Zadaci.Remove(taskZaBrisanje);
        }

        public void ObrisiTrening(int id)
        {
            var treningZaBrisanje = Treninzi.SingleOrDefault<Trening>(j => j.Id == id);
            if (treningZaBrisanje == null) return;
            Treninzi.Remove(treningZaBrisanje);
        }

        public void UrediJelo(int id, Jelo jelo)
        {
            var jeloZaPromjenu = Jela.SingleOrDefault<Jelo>(j => j.Id == id);
            if (jeloZaPromjenu == null) return;
            jeloZaPromjenu = jelo;
        }

        public void UrediZadatak(int id, Zadatak task)
        {
            var taskZaPromjenu = Zadaci.SingleOrDefault<Zadatak>(t => t.Id == id);
            if (taskZaPromjenu == null) return;
            taskZaPromjenu = task;
        }

        public void UrediTrening(int id, Trening trening)
        {
            var treningZaPromjenu = Treninzi.SingleOrDefault<Trening>(tr => tr.Id == id);
            if (treningZaPromjenu == null) return;
            treningZaPromjenu = trening;
        }
    }
}
