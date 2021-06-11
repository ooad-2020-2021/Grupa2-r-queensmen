using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public enum KategorijaJela
    {
        [Display(Name = "Nema kategorije")]
        Nedefinisano,
        [Display(Name = "Doručak")]
        Dorucak,
        [Display(Name = "Ručak")]
        Rucak,
        [Display(Name = "Večera")]
        Vecera
    }
}
