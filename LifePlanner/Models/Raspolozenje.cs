using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Raspolozenje
    {
        public int id { get; set; }
        public DateTime datum { get; set; }
        public TipRaspolozenja tipRaspolozenja { get; set; }
    }
}
