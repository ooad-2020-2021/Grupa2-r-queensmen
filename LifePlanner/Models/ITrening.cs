using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface ITrening
    {
        public void DodajTrening(Trening trening);
        public void ObrisiTrening(int id);
        public void UrediTrening(int id, Trening trening);
    }
}
