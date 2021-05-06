using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class RegistrovaniKorisnik : IVoda, ITask, IJelo, IRaspolozenje, ITrening
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Task> taskovi { get; set; }
        public List<Jelo> jela { get; set; }
        public List<Trening> treninzi { get; set; }
        public List<Voda> popijenaVoda { get; set; }
        public List<Raspolozenje> raspolozenja { get; set; }

        public void dodajJelo(Jelo jelo)
        {
            jela.Add(jelo);
        }

        public void dodajRaspolozenje(Raspolozenje raspolozenje)
        {
            raspolozenja.Add(raspolozenje);
        }

        public void dodajTask(Task task)
        {
            taskovi.Add(task);
        }

        public void dodajTrening(Trening trening)
        {
            treninzi.Add(trening);
        }

        public void dodajVodu(Voda voda)
        {
            popijenaVoda.Add(voda);
        }

        public void obrisiJelo(int id)
        {
            var jeloZaBrisanje = jela.SingleOrDefault<Jelo>(j => j.id == id);
            if (jeloZaBrisanje == null) return;
            jela.Remove(jeloZaBrisanje);
        }

        public void obrisiTask(int id)
        {
            var taskZaBrisanje = taskovi.SingleOrDefault<Task>(j => j.id == id);
            if (taskZaBrisanje == null) return;
            taskovi.Remove(taskZaBrisanje);
        }

        public void obrisiTrening(int id)
        {
            var treningZaBrisanje = treninzi.SingleOrDefault<Trening>(j => j.id == id);
            if (treningZaBrisanje == null) return;
            treninzi.Remove(treningZaBrisanje);
        }

        public void urediJelo(int id, Jelo jelo)
        {
            var jeloZaPromjenu = jela.SingleOrDefault<Jelo>(j => j.id == id);
            if (jeloZaPromjenu == null) return;
            jeloZaPromjenu = jelo;
        }

        public void urediTask(int id, Task task)
        {
            var taskZaPromjenu = taskovi.SingleOrDefault<Task>(t => t.id == id);
            if (taskZaPromjenu == null) return;
            taskZaPromjenu = task;
        }

        public void urediTrening(int id, Trening trening)
        {
            var treningZaPromjenu = treninzi.SingleOrDefault<Trening>(tr => tr.id == id);
            if (treningZaPromjenu == null) return;
            treningZaPromjenu = trening;
        }
    }
}
