using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Task
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public DateTime datum { get; set; }
    }
}
