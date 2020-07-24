using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierPlant.Models
{
    public class Plante
    {
        [Key]
        public int id { get; set; }
        [MaxLength(40, ErrorMessage = "taille max 40"),
        Required(ErrorMessage = "*")]
        [Display(Name = "Designation")]
        public string designation { get; set; }


        [Display(Name = "Date Plante"), DataType(DataType.DateTime), Required(ErrorMessage = "*")]
        public DateTime datePlante { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Taille")]
        public int Taille { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Poids")]
        public double Poids { get; set; }
        [MaxLength(40, ErrorMessage = "taille max 40"),
        Required(ErrorMessage = "*")]
        [Display(Name = "Humidite")]
        public string Humidite { get; set; }

    }
}