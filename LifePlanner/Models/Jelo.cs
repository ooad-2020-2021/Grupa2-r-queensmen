using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class Jelo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [EnumDataType(typeof(KategorijaJela))]
        [Required]
        [Display(Name = "KategorijaJela: ")]
        public KategorijaJela Kategorija { get; set; }
      
        public IList<string> Sastojci { get; set; }

        [Required]
        public RegistrovaniKorisnik Korisnik { get; set; }

        [Required]
        public int KorisnikID { get; set; }
    }
}
