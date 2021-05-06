using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class RegistrovaniKorisnik : IVoda, ITask, IJelo, IRaspolozenje, ITrening
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Task> Taskovi { get; set; }
        public List<Jelo> Jela { get; set; }
        public List<Trening> Treninzi { get; set; }
        public List<Voda> PopijenaVoda { get; set; }
        public List<Raspolozenje> Raspolozenja { get; set; }

        public void dodajJelo(Jelo jelo)
        {
            Jela.Add(jelo);
        }

        public void dodajRaspolozenje(Raspolozenje raspolozenje)
        {
            Raspolozenja.Add(raspolozenje);
        }

        public void dodajTask(Task task)
        {
            Taskovi.Add(task);
        }

        public void dodajTrening(Trening trening)
        {
            Treninzi.Add(trening);
        }

        public void dodajVodu(Voda voda)
        {
            PopijenaVoda.Add(voda);
        }

        public void obrisiJelo(int id)
        {
            var jeloZaBrisanje = Jela.SingleOrDefault<Jelo>(j => j.id == id);
            if (jeloZaBrisanje == null) return;
            Jela.Remove(jeloZaBrisanje);
        }

        public void obrisiTask(int id)
        {
            var taskZaBrisanje = Taskovi.SingleOrDefault<Task>(j => j.id == id);
            if (taskZaBrisanje == null) return;
            Taskovi.Remove(taskZaBrisanje);
        }

        public void obrisiTrening(int id)
        {
            var treningZaBrisanje = Treninzi.SingleOrDefault<Trening>(j => j.id == id);
            if (treningZaBrisanje == null) return;
            Treninzi.Remove(treningZaBrisanje);
        }

        public void urediJelo(int id, Jelo jelo)
        {
            var jeloZaPromjenu = Jela.SingleOrDefault<Jelo>(j => j.id == id);
            if (jeloZaPromjenu == null) return;
            jeloZaPromjenu = jelo;
        }

        public void urediTask(int id, Task task)
        {
            var taskZaPromjenu = Taskovi.SingleOrDefault<Task>(t => t.id == id);
            if (taskZaPromjenu == null) return;
            taskZaPromjenu = task;
        }

        public void urediTrening(int id, Trening trening)
        {
            var treningZaPromjenu = Treninzi.SingleOrDefault<Trening>(tr => tr.id == id);
            if (treningZaPromjenu == null) return;
            treningZaPromjenu = trening;
        }
    }
}
