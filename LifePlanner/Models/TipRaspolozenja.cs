using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public enum TipRaspolozenja
    {
        [Display(Name = "Dobro")]
        Dobro,
        [Display(Name = "Srednje")]
        Srednje,
        [Display(Name = "Loše")]
        Lose
    }
}
