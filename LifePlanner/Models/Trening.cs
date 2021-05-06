using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Trening
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<string> Vjezbe { get; set; }
    }
}
