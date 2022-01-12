using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class KontoModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Musisz podać Email")]
        [EmailAddress(ErrorMessage = "Podaj poprawny Email")]
        public string Email { get; set; }
        [Display(Name = "Hasło: ")]
        [Required(ErrorMessage = "Musisz podać Hasło")]
        [MinLength(8,ErrorMessage = "Hasło musi zawierać minimum 8 znaków")]
        public string HasloHASH { get; set; }
        [Display(Name = "Imie: ")]
        [Required(ErrorMessage = "Musisz podać Imie")]
        [MaxLength(60)]
        public string Imie { get; set; }
        [Display(Name = "Nazwisko: ")]
        [Required(ErrorMessage = "Musisz podać Nazwisko")]
        [MaxLength(60)]
        public string Nazwisko { get; set; }
        [Display(Name = "Telefon: ")]
        [Phone(ErrorMessage = "Podaj poprawny numer telefonu")]
        public string Telefon { get; set; }
        [ScaffoldColumn(false)]
        public bool PrawaAdministratora { get; set; }
    }
}
