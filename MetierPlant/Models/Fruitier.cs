using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MetierPlant.Models
{

    [Table("Fruitier")]
    public class Fruitier : Plante
    {
        [Required]
        [Display(Name = "Type"), MaxLength(20)]
        public string Type { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateSemanance")]
        public DateTime? DateSemanance { get; set; }
    }
}