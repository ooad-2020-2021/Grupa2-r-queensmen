using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Trening
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public List<string> vjezbe { get; set; }
    }
}
