using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using SRSK.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace SRSK.Controllers
{
    public class StartController : Controller
    {
        //------------------------------------------------------------------------ STRONA STARTOWA --------------------------------------------------------------------------
        // GET: Start/Index
        public IActionResult Index()
        {
            List<WiadomoscModel> wiadomosci = new List<WiadomoscModel>();
            BazaDanych baza = new BazaDanych();
            baza.Polaczenie.Open();
            SqlDataReader r = baza.WykonajPobierz("SELECT TOP (10) * FROM [srskBaza].[dbo].[Wiadomosc] ORDER BY [Data] DESC");
            while(r.Read())
            {
                wiadomosci.Add(new WiadomoscModel() { 
                    Id = Convert.ToInt32(r["Id"]),
                    Data = Convert.ToDateTime(r["Data"]),
                    Tytul = r["Tytul"].ToString(),
                    Tresc = r["Tresc"].ToString(),
                    IdKonto = Convert.ToInt32(r["IdKonto"])
                });
            }
            baza.Polaczenie.Close();
            return View(wiadomosci);
        }

        //-------------------------------------------------------------------------- INFORMACJE ---------------------------------------------------------------------------------
        public IActionResult Informacje()
        {
            return View();
        }

        //-------------------------------------------------------------------------- Kontakt -------------------------------------------------------------------------------------
        public IActionResult Kontakt()
        {
            return View();
        }
    }
}
