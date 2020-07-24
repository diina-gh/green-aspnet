using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MetierPlant.Models
{
    [Table("profil")]
    public class Profil
    {
        [Key]
        public int IdProfil { get; set; }

        [Display(Name = "Libellé profil"), MaxLength(30, ErrorMessage = "La taille maximale est de 20 caractères"), Required(ErrorMessage = "*")]
        public string LibelleProfil { get; set; }
    }
}
