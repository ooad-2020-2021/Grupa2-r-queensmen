using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    interface ITask
    {
        public void DodajTask(Task task);
        public void ObrisiTask(int id);
        public void UrediTask(int id, Task task);
    }
}
