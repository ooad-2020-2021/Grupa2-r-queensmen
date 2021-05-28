using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface IJelo
    {
        public void DodajJelo(Jelo jelo);
        public void ObrisiJelo(Guid id);
        public void UrediJelo(Guid id, Jelo jelo);
    }
}
