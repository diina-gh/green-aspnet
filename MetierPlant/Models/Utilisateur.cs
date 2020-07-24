using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MetierPlant.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdU { get; set; }
        [Display(Name = "Nom prénom"), MaxLength(160, ErrorMessage = "La taille maximale est de 160 caractères"), Required(ErrorMessage = "*")]
        public string NomPrenomU { get; set; }
        [Display(Name = "Identifiant"), MaxLength(20, ErrorMessage = "La taille maximale est de 20 caractères"), Required(ErrorMessage = "*")]
        public string IdentifiantU { get; set; }
        [Display(Name = "Email"), MaxLength(30, ErrorMessage = "La taille maximale est de 30 caractères"), Required(ErrorMessage = "*")]
        public string EmailU { get; set; }
        [Display(Name = "Téléphone"), MaxLength(20, ErrorMessage = "La taille maximale est de 20 caractères"), Required(ErrorMessage = "*")]
        public string TelU { get; set; }
        [Display(Name = "User"), MaxLength(80, ErrorMessage = "La taille maximale est de 30")]
        public string IdUser { get; set; }

    }
}