using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface ITask
    {
        public void dodajTask(Task task);
        public void obrisiTask(int id);
        public void urediTask(int id, Task task);
    }
}
