using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class BudynekModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Miasto { get; set; }
        public string Adres { get; set; }
        public int Pietra { get; set; }
        public string Informacje { get; set; }
    }
}
