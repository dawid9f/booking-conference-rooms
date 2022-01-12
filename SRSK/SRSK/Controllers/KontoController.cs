using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSK.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SRSK.Controllers
{
    public class KontoController : Controller
    {
        //-------------------------------------------------------- UKRYWANIE HASLA -----------------------------------------------------
        private string HashSHA256(string haslo)
        {
            if (haslo == null) haslo = "";
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(haslo));
            StringBuilder Sb = new StringBuilder();
            foreach (Byte b in bytes)
            {
                Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        //------------------------------------------- SPRAWDZA CZY ZALOGOWANY ORAZ CZY JEST PRACOWNIKIEM -------------------------------
        public int Zalogowany()
        {
            if(HttpContext.Session.GetString("Id") != null && HttpContext.Session.GetString("Nazwa") != null && HttpContext.Session.GetString("Admin") != null)
            {
                if (HttpContext.Session.GetString("Admin") == "True")
                {
                    return 2;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //------------------------------------------------------- WYLOGOWANIE KONTA ----------------------------------------------------
        public ActionResult LogOut()
        {
            if (HttpContext.Session.GetString("Id") != null)
                HttpContext.Session.Remove("Id");

            if (HttpContext.Session.GetString("Nazwa") != null)
                HttpContext.Session.Remove("Nazwa");

            if (HttpContext.Session.GetString("Admin") != null)
                HttpContext.Session.Remove("Admin");

            return RedirectToAction("Logowanie", "Konto");
        }

        //------------------------------------------ WYSWIETLANIE FORMULARZA REJESTRACJI -----------------------------------------------
        // GET: Konto/Rejestracja
        public ActionResult Rejestracja()
        {
            if(Zalogowany() > 0)
            {
                return RedirectToAction("Informacje", "Konto");
            }
            else
            {
                ViewBag.Info = "";
                return View(new KontoModel());
            }
        }

        //------------------------------------------ SPRAWDZANIE DANYCH ORAZ REJESTRACJA -----------------------------------------------
        // POST: Konto/Rejestracja
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rejestracja(KontoModel konto)
        {
            if(Zalogowany() > 0)
            {
                return RedirectToAction("Informacje", "Konto");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View("Rejestracja", konto);
                }
                else
                {
                    BazaDanych baza = new BazaDanych();
                    baza.Polaczenie.Open();
                    SqlDataReader r = baza.WykonajPobierz("SELECT [Email] FROM [srskBaza].[dbo].[Konto] WHERE [Email] = '" + konto.Email + "';");
                    if (r.Read())
                    {
                        baza.Polaczenie.Close();
                        ViewBag.Info = "Istnieje już konto przypisane do tego adresu email";
                        return View("Rejestracja", konto);
                    }
                    else
                    {
                        konto.HasloHASH = HashSHA256(konto.HasloHASH);
                        baza.Polaczenie.Close();
                        baza.Polaczenie.Open();
                        baza.Wykonaj("INSERT INTO [srskBaza].[dbo].[Konto] ([Email],[HasloHASH],[Imie],[Nazwisko],[Telefon],[PrawaAdministratora]) VALUES ('" + konto.Email + "','" + konto.HasloHASH + "','" + konto.Imie + "','" + konto.Nazwisko + "','" + konto.Telefon + "',0);");
                        baza.Polaczenie.Close();
                        ViewBag.Info = "Konto zostało zarejestrowane";
                        return View("Logowanie");
                    }
                }
            }
        }

        //------------------------------------------ WYSWIETLANIE FORMULARZA LOGOWANIA -----------------------------------------------
        // GET: Konto/Logowanie
        public ActionResult Logowanie()
        {
            if(Zalogowany() > 0)
            {
                return RedirectToAction("Informacje", "Konto");
            }
            else
            {
                ViewBag.Info = "";
                return View(new KontoModel());
            }
        }

        //------------------------------------------------------- LOGOWANIE ----------------------------------------------------------
        // POST: Konto/Logowanie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logowanie(KontoModel konto)
        {
            if(Zalogowany() > 0)
            {
                return RedirectToAction("Informacje", "Konto");
            }
            else
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader rr = baza.WykonajPobierz("SELECT k.Email FROM [srskBaza].[dbo].[Blokada] as b LEFT JOIN [srskBaza].[dbo].[Konto] as k ON b.IdKonto=k.Id WHERE k.Email = '" + konto.Email + "' AND b.DataDo >= CAST('" + DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss") + "' as DATETIME);");
                if(rr.Read())
                {
                    rr.Close();
                    baza.Polaczenie.Close();
                    ViewBag.Info = "Konto przypisane do tego maila jest zablokowane";
                    return View("Logowanie", konto);
                }
                else
                {
                    rr.Close();
                    baza.Polaczenie.Close();
                    string hasloH = HashSHA256(konto.HasloHASH);
                    baza.Polaczenie.Open();
                    SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Konto] WHERE [Email] = '" + konto.Email + "' AND [HasloHASH] = '" + hasloH + "';");
                    if (r.Read())
                    {
                        konto.Id = Convert.ToInt32(r["Id"]);
                        konto.Imie = r["Imie"].ToString();
                        konto.Nazwisko = r["Nazwisko"].ToString();
                        konto.PrawaAdministratora = Convert.ToBoolean(r["PrawaAdministratora"]);

                        HttpContext.Session.SetString("Id", konto.Id.ToString());
                        HttpContext.Session.SetString("Nazwa", konto.Imie + " " + konto.Nazwisko);
                        HttpContext.Session.SetString("Admin", konto.PrawaAdministratora.ToString());
                        r.Close();
                        baza.Polaczenie.Close();
                        return RedirectToAction("Informacje", "Konto");
                    }
                    else
                    {
                        baza.Polaczenie.Close();
                        ViewBag.Info = "Podałeś złe dane logowania";
                        return View("Logowanie", konto);
                    }
                }
            }
        }

        //-------------------------------------- WYŚWIETLANIE INFORMACJI O WŁASNYM KONCIE ORAZ REZERWACJACH ----------------------------
        // GET: Konto/Informacje
        public ActionResult Informacje()
        {
            int user = Zalogowany();
            if (user > 0)
            {
                ViewBag.Info = "";
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Konto] WHERE [Id] = '" + HttpContext.Session.GetString("Id") + "';");
                r.Read();
                KontoModel konto = new KontoModel() { 
                    Email = r["Email"].ToString(),
                    Imie = r["Imie"].ToString(),
                    Nazwisko = r["Nazwisko"].ToString(),
                    Telefon = r["Telefon"].ToString()
                };
                r.Close();
                
                if(user == 2)
                {
                    ViewBag.pracownik = "Panel Pracownika";
                }
                else
                {
                    ViewBag.pracownik = "";
                }

                List<RezerwacjeWyswietlanie> mojerezerwacje = new List<RezerwacjeWyswietlanie>();
                SqlDataReader rr = baza.WykonajPobierz("SELECT r.Id as Id, r.DataDo as DataDo, r.DataOd as DataOd, s.NrSali as NrSali, b.Symbol as Symbol FROM [srskBaza].[dbo].[Rezerwacja] as r LEFT JOIN [srskBaza].[dbo].[Sala] as s ON r.IdSala=s.Id LEFT JOIN [srskBaza].[dbo].[Budynek] as b ON s.IdBudynek=b.Id WHERE r.IdKonto=" + HttpContext.Session.GetString("Id") + " ORDER BY r.DataDo DESC;");
                while(rr.Read())
                {
                    mojerezerwacje.Add(new RezerwacjeWyswietlanie()
                    {
                        Id = Convert.ToInt32(rr["Id"]),
                        DataDo = Convert.ToDateTime(rr["DataDo"]),
                        DataOd = Convert.ToDateTime(rr["DataOd"]),
                        Budynek = rr["Symbol"].ToString(),
                        Sala = rr["NrSali"].ToString()
                    });
                }

                baza.Polaczenie.Close();
                ViewBag.mojerezerwacje = mojerezerwacje;
                return View(konto);
            }
            else
            {
                ViewBag.Info = "Musisz najpierw się zalogować";
                return View("Logowanie");
            }
        }

        //-------------------------------------- WYŚWIETLENIE FORMULARZA EDYCJI KONTA ----------------------------
        public ActionResult Edytuj()
        {
            if (Zalogowany() > 0)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Konto] WHERE [Id] = '" + HttpContext.Session.GetString("Id") + "';");
                r.Read();
                KontoModel konto = new KontoModel()
                {
                    Email = r["Email"].ToString(),
                    Imie = r["Imie"].ToString(),
                    Nazwisko = r["Nazwisko"].ToString(),
                    Telefon = r["Telefon"].ToString(),
                    HasloHASH = "12345678"
                };
                r.Close();
                baza.Polaczenie.Close();

                return View(konto);
            }
            else
            {
                ViewBag.Info = "Musisz najpierw się zalogować";
                return View("Logowanie");
            }
        }

        //-------------------------------------- EDYCJA KONTA ----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edytuj(KontoModel konto)
        {
            if (Zalogowany() > 0)
            {
                if (!ModelState.IsValid)
                {
                    return View("Edytuj", konto);
                }
                else
                {
                    BazaDanych baza = new BazaDanych();
                    baza.Polaczenie.Open();
                    baza.Wykonaj("UPDATE [srskBaza].[dbo].[Konto] SET Imie = '" + konto.Imie + "', Nazwisko = '" + konto.Nazwisko + "', Telefon = '" + konto.Telefon + "' WHERE Id = " + HttpContext.Session.GetString("Id") + ";");
                    baza.Polaczenie.Close();
                    return RedirectToAction("Informacje", "Konto");
                }
            }
            else
            {
                ViewBag.Info = "Musisz najpierw się zalogować";
                return View("Logowanie");
            }
        }
    }
}
