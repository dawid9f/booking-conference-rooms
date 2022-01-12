using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class RezerwacjaModel
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public int IdKonto { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
    }
}
