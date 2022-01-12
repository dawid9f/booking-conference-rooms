using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class AwariaModel
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public string Informacje { get; set; }

    }
}
