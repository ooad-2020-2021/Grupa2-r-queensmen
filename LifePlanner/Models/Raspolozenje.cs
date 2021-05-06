using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Raspolozenje
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TipRaspolozenja TipRaspolozenja { get; set; }
    }
}
