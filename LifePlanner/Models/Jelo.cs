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
        public Guid Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [EnumDataType(typeof(KategorijaJela))]
     
        [Display(Name = "Kategorija jela: ")]
        public KategorijaJela Kategorija { get; set; }
      
        public IList<string> Sastojci { get; set; }

        public RegistrovaniKorisnik Korisnik { get; set; }
    }
}
