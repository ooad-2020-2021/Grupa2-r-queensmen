using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifePlanner.Models;

namespace LifePlanner.Utility.Strategy
{
    public class BrojVjezbiSort : SortStrategy<Trening>
    {
        public IEnumerable<Trening> execute(IList<Trening> lista)
        {
            return lista.OrderBy(l => l.Vjezbe.Count());
        }
    }
}
