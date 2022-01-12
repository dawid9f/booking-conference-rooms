using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class BlokadaModel
    {
        public int Id { get; set; }
        public int IdKonto { get; set; }
        [Display(Name = "Do kiedy: ")]
        [Required(ErrorMessage = "Musisz podać date")]
        public DateTime DataDo { get; set; }
        [Display(Name = "Informacje: ")]
        [MaxLength(200)]
        [Required(ErrorMessage = "Musisz podać powód")]
        public string Informacje { get; set; }
    }
}
