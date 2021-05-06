using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface ITrening
    {
        public void dodajTrening(Trening trening);
        public void obrisiTrening(int id);
        public void urediTrening(int id, Trening trening);
    }
}
