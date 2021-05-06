using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface IJelo
    {
        public void dodajJelo(Jelo jelo);
        public void obrisiJelo(int id);
        public void urediJelo(int id, Jelo jelo);
    }
}
