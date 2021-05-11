using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class RegistrovaniKorisnik : IVoda, ITask, IJelo, IRaspolozenje, ITrening
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        public List<Task> Taskovi { get; set; }

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
