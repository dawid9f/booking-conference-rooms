using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class WiadomoscModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Data wstawienia: ")]
        public DateTime Data { get; set; }
        [Display(Name = "Tytuł: ")]
        [MaxLength(200)]
        [Required(ErrorMessage = "Musisz podać Tytuł")]
        public string Tytul { get; set; }
        [Display(Name = "Treść: ")]
        [MaxLength(8000)]
        [Required(ErrorMessage = "Musisz podać Treść")]
        public string Tresc { get; set; }
        [ScaffoldColumn(false)]
        public int IdKonto { get; set; }
    }
}
