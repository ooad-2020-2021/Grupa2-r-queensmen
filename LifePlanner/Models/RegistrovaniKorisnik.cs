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

        public void DodajJelo(Jelo jelo)
        {
            Jela.Add(jelo);
        }

        public void DodajRaspolozenje(Raspolozenje raspolozenje)
        {
            Raspolozenja.Add(raspolozenje);
        }

        public void DodajTask(Task task)
        {
            Taskovi.Add(task);
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

        public void ObrisiTask(int id)
        {
            var taskZaBrisanje = Taskovi.SingleOrDefault<Task>(j => j.Id == id);
            if (taskZaBrisanje == null) return;
            Taskovi.Remove(taskZaBrisanje);
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

        public void UrediTask(int id, Task task)
        {
            var taskZaPromjenu = Taskovi.SingleOrDefault<Task>(t => t.Id == id);
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
