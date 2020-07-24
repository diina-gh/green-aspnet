using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MetierPlant.Models
{
    [Table("Marecher")]
    public class Marecher : Plante
    {
        [Required]
        [Display(Name = "Semanance"), MaxLength(20)]
        public string Semanance { get; set; }
        [Required]
        [Display(Name = "Période")]
        public int? Periode { get; set; }
    }
}