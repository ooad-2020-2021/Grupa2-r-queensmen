using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface IZadatak
    {
        public void DodajZadatak(Zadatak task);
        public void ObrisiZadatak(Guid id);
        public void UrediZadatak(Guid id, Zadatak task);
    }
}
