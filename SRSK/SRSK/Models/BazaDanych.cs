using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Models
{
    public class BazaDanych
    {
        public string StringPolaczenia { get; set; }

        public SqlConnection Polaczenie { get; set; }

        public BazaDanych()
        {
            StringPolaczenia = 
                "Server=DESKTOP-ARISVA1;" +
                "Database=srskBaza;" +
                "Trusted_Connection=True;";

            Polaczenie = new SqlConnection(StringPolaczenia);
        }

        public BazaDanych(String stringPolaczenia)
        {
            StringPolaczenia = stringPolaczenia;

            Polaczenie = new SqlConnection(StringPolaczenia);
        }

        public void Wykonaj(string polecenie)
        {
            SqlCommand pol = new SqlCommand(polecenie, Polaczenie);
            pol.ExecuteNonQuery();
        }

        public SqlDataReader WykonajPobierz(string polecenie)
        {
            SqlCommand pol = new SqlCommand(polecenie, Polaczenie);
            SqlDataReader reader = pol.ExecuteReader();
            return reader;
        }
    }

}
