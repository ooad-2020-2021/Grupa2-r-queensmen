using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface IJelo
    {
        public void DodajJelo(Jelo jelo);
        public void ObrisiJelo(int id);
        public void UrediJelo(int id, Jelo jelo);
    }
}
