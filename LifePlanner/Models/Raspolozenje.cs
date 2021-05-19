using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Raspolozenje
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display (Name = "Datum: ")]
        public DateTime Datum { get; set; }

        [EnumDataType(typeof (TipRaspolozenja))]
        [Required]
        [Display(Name = "Raspolozenje: ")]
        public TipRaspolozenja TipRaspolozenja { get; set; }

        [Required]
        public RegistrovaniKorisnik Korisnik { get; set; }

        [Required]
        public int KorisnikId { get; set; }
    }
}
