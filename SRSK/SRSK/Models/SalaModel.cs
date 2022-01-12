using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class SalaModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Numer sali: ")]
        [Required(ErrorMessage = "Musisz podać numer sali")]
        public int NrSali { get; set; }
        [Display(Name = "Piętro: ")]
        [Required(ErrorMessage = "Musisz podać piętro")]
        public int Pietro { get; set; }
        [Display(Name = "Ilość Miejsc: ")]
        [Required(ErrorMessage = "Musisz podać ilość miejsc")]
        public int IloscMiejsc { get; set; }
        [Display(Name = "Informacje: ")]
        [MaxLength(200)]
        public string Informacje { get; set; }
        public int IdBudynek { get; set; }
    }
}
