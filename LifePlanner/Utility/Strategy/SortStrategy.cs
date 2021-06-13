using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Utility.Strategy
{
    public interface SortStrategy<T>
    {
        public IEnumerable<T> execute(IList<T> lista);
    }
}
