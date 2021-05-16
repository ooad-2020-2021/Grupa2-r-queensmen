using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface IZadatak
    {
        public void DodajZadatak(Zadatak task);
        public void ObrisiZadatak(int id);
        public void UrediZadatak(int id, Zadatak task);
    }
}
