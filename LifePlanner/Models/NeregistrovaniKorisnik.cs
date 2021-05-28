using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifePlanner.Models
{
    public class NeregistrovaniKorisnik
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
