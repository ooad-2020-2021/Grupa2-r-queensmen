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
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display (Name = "Datum: ")]
        public DateTime Datum { get; set; }

        [EnumDataType(typeof (TipRaspolozenja))]
        [Required]
        [Display(Name = "Raspoloženje: ")]
        public TipRaspolozenja TipRaspolozenja { get; set; }

        public RegistrovaniKorisnik Korisnik { get; set; }
    }
}
