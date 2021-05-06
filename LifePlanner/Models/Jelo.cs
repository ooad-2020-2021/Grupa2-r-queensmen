using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public KategorijaJela Kategorija { get; set; }
        public List<string> Sastojci { get; set; }
    }
}
