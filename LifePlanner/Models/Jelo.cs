using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Jelo
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public KategorijaJela kategorija { get; set; }
        public List<string> sastojci { get; set; }
    }
}
