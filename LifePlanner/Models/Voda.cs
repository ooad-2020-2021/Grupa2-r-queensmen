using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Voda
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Datum: ")]
        public DateTime Datum { get; set; }

        [Required]
        public decimal Kolicina { get; set; }

        public RegistrovaniKorisnik Korisnik { get; set; }
    }
}
