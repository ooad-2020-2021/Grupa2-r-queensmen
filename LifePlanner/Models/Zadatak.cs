using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Zadatak
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Datum: ")]
        public DateTime Datum { get; set; }

        public RegistrovaniKorisnik Korisnik { get; set; }
    }
}
