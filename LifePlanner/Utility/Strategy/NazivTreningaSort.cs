using LifePlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Utility.Strategy
{
    public class NazivTreningaSort : SortStrategy<Trening>
    {
        public IEnumerable<Trening> execute(IList<Trening> lista)
        {
            return lista.OrderBy(l => l.Naziv);
        }
    }
}
