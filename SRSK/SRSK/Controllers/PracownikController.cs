using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSK.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SRSK.Controllers
{
    public class PracownikController : Controller
    {
        //-------------------------------------------------------- SPRAWDZA CZY ZALOGOWANY ORAZ CZY JEST PRACOWNIKIEM -----------------------------------------------------
        public int Zalogowany()
        {
            if (HttpContext.Session.GetString("Id") != null && HttpContext.Session.GetString("Nazwa") != null && HttpContext.Session.GetString("Admin") != null)
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

        //------------------------------------------------------------------------ PANEL PRACOWNIKA --------------------------------------------------------------------------
        // GET: PracownikController
        public ActionResult Index()
        {
            if(Zalogowany() == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        //--------------------------------------------------------------------------- WPISY ----------------------------------------------------------------------------------
        // GET: PracownikController/Wpisy
        public ActionResult Wpisy()
        {
            if (Zalogowany() == 2)
            {
                List<WiadomoscModel> wpisy = new List<WiadomoscModel>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Wiadomosc] ORDER BY [Data] DESC;");
                while (r.Read())
                {
                    wpisy.Add(new WiadomoscModel()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Data = Convert.ToDateTime(r["Data"]),
                        Tytul = r["Tytul"].ToString(),
                        Tresc = r["Tresc"].ToString(),
                        IdKonto = Convert.ToInt32(r["IdKonto"])
                    });
                }
                baza.Polaczenie.Close();

                return View(wpisy);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

       

        // GET: PracownikController/CzytajWpis/id
        public ActionResult CzytajWpis(int id)
        {
            WiadomoscModel w = new WiadomoscModel();
            BazaDanych baza = new BazaDanych();
            baza.Polaczenie.Open();
            SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Wiadomosc] WHERE [Id] = " + id + ";");
            if (r.Read())
            {
                w.Id = Convert.ToInt32(r["Id"]);
                w.Data = Convert.ToDateTime(r["Data"]);
                w.Tytul = r["Tytul"].ToString();
                w.Tresc = r["Tresc"].ToString();
                w.IdKonto = Convert.ToInt32(r["IdKonto"]);
            }
            baza.Polaczenie.Close();
            return View(w);
        }

        // GET: PracownikController/UsunWpis/id
        public ActionResult UsunWpis(int id)
        {
            if (Zalogowany() == 2)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Wiadomosc] WHERE [Id] = " + id + ";");
                baza.Polaczenie.Close();
                return RedirectToAction("Wpisy", "Pracownik");
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }


        // GET: PracownikController/DodajWpis
        public ActionResult DodajWpis()
        {
            if (Zalogowany() == 2)
            {
                return View(new WiadomoscModel());
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // POST: PracownikController/DodajWpis
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajWpis(WiadomoscModel wiadomosc)
        {
            if (Zalogowany() == 2)
            {
                if (!ModelState.IsValid)
                {
                    return View("DodajWpis", wiadomosc);
                }
                else
                {
                    BazaDanych baza = new BazaDanych();
                    baza.Polaczenie.Open();
                    baza.Wykonaj("INSERT INTO [srskBaza].[dbo].[Wiadomosc] ([Tytul], [Tresc], [IdKonto]) VALUES('" + wiadomosc.Tytul + "','" + wiadomosc.Tresc + "'," + HttpContext.Session.GetString("Id") + ");");
                    baza.Polaczenie.Close();
                    return RedirectToAction("Wpisy", "Pracownik");
                }
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        //-------------------------------------------------------- KONTA -----------------------------------------------------
        // GET: PracownikController/Klienci
        public ActionResult Klienci()
        {
            if (Zalogowany() == 2)
            {
                List<KontoModel> klienci = new List<KontoModel>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT [Id], [Email], [Imie], [Nazwisko], [Telefon] FROM [srskBaza].[dbo].[Konto] WHERE [PrawaAdministratora] = '0';");
                while(r.Read())
                {
                    klienci.Add(new KontoModel() 
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Email = r["Email"].ToString(),
                        Imie = r["Imie"].ToString(),
                        Nazwisko = r["Nazwisko"].ToString(),
                        Telefon = r["Telefon"].ToString()
                    });
                }
                baza.Polaczenie.Close();
                return View(klienci);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // GET: PracownikController/Pracownicy
        public ActionResult Pracownicy()
        {
            if (Zalogowany() == 2)
            {
                List<KontoModel> pracownicy = new List<KontoModel>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT [Id], [Email], [Imie], [Nazwisko], [Telefon] FROM [srskBaza].[dbo].[Konto] WHERE [PrawaAdministratora] = '1' AND [Id] != "+ HttpContext.Session.GetString("Id") + ";");
                while (r.Read())
                {
                    pracownicy.Add(new KontoModel()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Email = r["Email"].ToString(),
                        Imie = r["Imie"].ToString(),
                        Nazwisko = r["Nazwisko"].ToString(),
                        Telefon = r["Telefon"].ToString()
                    });
                }
                baza.Polaczenie.Close();
                return View(pracownicy);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // GET: PracownikController/Informacje/Id
        public ActionResult Informacje(int id)
        {
            if (Zalogowany() == 2)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Konto] WHERE [Id] = '" + id + "';");
                r.Read();
                KontoModel konto = new KontoModel()
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Email = r["Email"].ToString(),
                    Imie = r["Imie"].ToString(),
                    Nazwisko = r["Nazwisko"].ToString(),
                    Telefon = r["Telefon"].ToString()
                };
                r.Close();
                List<RezerwacjeWyswietlanie> mojerezerwacje = new List<RezerwacjeWyswietlanie>();
                SqlDataReader rr = baza.WykonajPobierz("SELECT r.Id as Id, r.DataDo as DataDo, r.DataOd as DataOd, s.NrSali as NrSali, b.Symbol as Symbol FROM [srskBaza].[dbo].[Rezerwacja] as r LEFT JOIN [srskBaza].[dbo].[Sala] as s ON r.IdSala=s.Id LEFT JOIN [srskBaza].[dbo].[Budynek] as b ON s.IdBudynek=b.Id WHERE r.IdKonto=" + id + " ORDER BY r.DataDo DESC;");
                while (rr.Read())
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
                return RedirectToAction("Informacje", "Konto");
            }
        }

        private void UsunRezWiaBloKonta(int id)
        {
            BazaDanych baza = new BazaDanych();
            baza.Polaczenie.Open();
            baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Wiadomosc] WHERE [IdKonto] = " + id + ";");
            baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Rezerwacja] WHERE [IdKonto] = " + id + ";");
            baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Blokada] WHERE [IdKonto] = " + id + ";");
            baza.Polaczenie.Close();
        }


        // GET: PracownikController/BlokujKonto/Id
        public ActionResult BlokujKonto(int id)
        {
            if (Zalogowany() == 2)
            {
                BlokadaModel blokada = new BlokadaModel()
                {
                    IdKonto = id,
                    DataDo = DateTime.Now
                };
                return View(blokada);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // POST: PracownikController/BlokujKonto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BlokujKonto(BlokadaModel blokada)
        {
            if (!ModelState.IsValid)
            {
                return View("BlokujKonto", blokada);
            }
            else
            {
                TimeSpan d = blokada.DataDo - DateTime.Now;
                if(d.TotalMinutes < 15)
                {
                    ViewBag.Info = "Minimalny czas blokady to 15 minut";
                    return View("BlokujKonto", blokada);
                }
                else
                {
                    UsunRezWiaBloKonta(blokada.IdKonto);
                    BazaDanych baza = new BazaDanych();
                    baza.Polaczenie.Open();
                    baza.Wykonaj("INSERT INTO [srskBaza].[dbo].[Blokada] ([IdKonto], [DataDo], [Informacje]) VALUES(" + blokada.IdKonto + ", '" + blokada.DataDo.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + blokada.Informacje + "')");
                    baza.Polaczenie.Close();
                    return RedirectToAction("Blokady", "Pracownik");
                }
            }
        }

        // GET: PracownikController/UsunKonto/Id
        public ActionResult UsunKonto(int id)
        {
            if (Zalogowany() == 2)
            {
                UsunRezWiaBloKonta(id);
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Konto] WHERE [Id] = " + id + ";");
                baza.Polaczenie.Close();
                return RedirectToAction("Index", "Pracownik");
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // GET: PracownikController/Zatrudnij/Id
        public ActionResult Zatrudnij(int id)
        {
            if (Zalogowany() == 2)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                baza.Wykonaj("UPDATE [srskBaza].[dbo].[Konto] SET  [PrawaAdministratora] = 'True' WHERE Id = " + id + ";");
                baza.Polaczenie.Close();
                return RedirectToAction("Klienci", "Pracownik");
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // GET: PracownikController/Zwolnij/Id
        public ActionResult Zwolnij(int id)
        {
            if (Zalogowany() == 2)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                baza.Wykonaj("UPDATE [srskBaza].[dbo].[Konto] SET  [PrawaAdministratora] = 'False' WHERE Id = " + id + ";");
                baza.Polaczenie.Close();
                return RedirectToAction("Pracownicy", "Pracownik");
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // GET: PracownikController/Blokady
        public ActionResult Blokady()
        {
            if (Zalogowany() == 2)
            {
                List<BlokadaWyswietlanie> blokady = new List<BlokadaWyswietlanie>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT b.Id as Id, b.IdKonto as IdKonto, b.DataDo as DataDo, b.Informacje as Informacje, k.Email as Email, k.Imie as Imie, k.Nazwisko as Nazwisko FROM [srskBaza].[dbo].[Blokada] as b LEFT JOIN [srskBaza].[dbo].[Konto] as k ON b.IdKonto=k.Id;");
                while (r.Read())
                {
                    blokady.Add(new BlokadaWyswietlanie()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        IdKonto = Convert.ToInt32(r["IdKonto"]),
                        DataDo = Convert.ToDateTime(r["DataDo"]),
                        Informacje = r["Informacje"].ToString(),
                        Email = r["Email"].ToString(),
                        Imie = r["Imie"].ToString(),
                        Nazwisko = r["Nazwisko"].ToString()
                    });
                }
                baza.Polaczenie.Close();
                return View(blokady);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        // GET: PracownikController/Odblokuj/Id
        public ActionResult Odblokuj(int id)
        {
            if (Zalogowany() == 2)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Blokada] WHERE [Id] = " + id + ";");
                baza.Polaczenie.Close();
                return RedirectToAction("Blokady", "Pracownik");
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        //-------------------------------------------------------- REZERWACJE -----------------------------------------------------
        // GET: PracownikController/Odblokuj/Id
        public ActionResult Rezerwacje()
        {
            if (Zalogowany() == 2)
            {
                List<RezerwacjeWyswietlanie> rezerwacje = new List<RezerwacjeWyswietlanie>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT r.Id as Id, r.IdKonto as IdKonto, r.DataDo as DataDo, r.DataOd as DataOd, s.NrSali as NrSali, b.Symbol as Symbol FROM [srskBaza].[dbo].[Rezerwacja] as r LEFT JOIN [srskBaza].[dbo].[Sala] as s ON r.IdSala=s.Id LEFT JOIN [srskBaza].[dbo].[Budynek] as b ON s.IdBudynek=b.Id ORDER BY r.DataDo DESC;");
                while (r.Read())
                {
                    rezerwacje.Add(new RezerwacjeWyswietlanie() 
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        DataDo = Convert.ToDateTime(r["DataDo"]),
                        DataOd = Convert.ToDateTime(r["DataOd"]),
                        Budynek = r["Symbol"].ToString(),
                        Sala = r["NrSali"].ToString(),
                        IdKonto = Convert.ToInt32(r["IdKonto"])
                    });
                }
                r.Close();
                baza.Polaczenie.Close();
                return View(rezerwacje);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        //-------------------------------------------------------- AWARIE -----------------------------------------------------
        // GET: PracownikController/Awarie
        public ActionResult Awarie()
        {
            if (Zalogowany() == 2)
            {
                List<AwarieWyswietlanie> awarie = new List<AwarieWyswietlanie>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT a.Id as Id, a.IdSala as IdSala, a.DataOd as DataOd, a.DataDo as DataDo, a.Informacje as Informacje, b.Symbol as Budynek, s.NrSali as Sala FROM [srskBaza].[dbo].[Awaria] as a INNER JOIN [srskBaza].[dbo].[Sala] as s ON a.IdSala=s.Id INNER JOIN [srskBaza].[dbo].[Budynek] as b ON s.IdBudynek=b.Id ORDER BY a.DataDo DESC;");
                while (r.Read())
                {
                    awarie.Add(new AwarieWyswietlanie()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        IdSala = Convert.ToInt32(r["IdSala"]),
                        DataDo = Convert.ToDateTime(r["DataDo"]),
                        DataOd = Convert.ToDateTime(r["DataOd"]),
                        Informacje = r["Informacje"].ToString(),
                        Budynek = r["Budynek"].ToString(),
                        Sala = r["Sala"].ToString()
                    });
                }
                r.Close();
                baza.Polaczenie.Close();
                return View(awarie);
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        public ActionResult UsunAwarie(int id)
        {
            if (Zalogowany() == 2)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Awaria] WHERE [Id] = " + id + ";");
                baza.Polaczenie.Close();
                return RedirectToAction("Awarie", "Pracownik");
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }   
        }

        public ActionResult DodajAwarie()
        {
            if (Zalogowany() == 2)
            {
                List<BudynekModel> budynki = new List<BudynekModel>();
                List<SalaModel> sale = new List<SalaModel>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Budynek]");
                while (r.Read())
                {
                    budynki.Add(new BudynekModel()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Symbol = r["Symbol"].ToString(),
                        Adres = r["Adres"].ToString(),
                        Miasto = r["Miasto"].ToString(),
                        Informacje = r["Informacje"].ToString(),
                        Pietra = Convert.ToInt32(r["Pietra"])
                    });
                }
                r.Close();
                r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Sala]");
                while (r.Read())
                {
                    sale.Add(new SalaModel()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        NrSali = Convert.ToInt32(r["NrSali"]),
                        Pietro = Convert.ToInt32(r["Pietro"]),
                        IloscMiejsc = Convert.ToInt32(r["IloscMiejsc"]),
                        Informacje = r["Informacje"].ToString(),
                        IdBudynek = Convert.ToInt32(r["IdBudynek"])
                    });
                }
                r.Close();
                baza.Polaczenie.Close();
                ViewBag.budynki = budynki;
                ViewBag.sale = sale;
                return View();
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajAwarie(IFormCollection form)
        {
            if (Zalogowany() == 2)
            {
                if (Convert.ToInt32(form["IdS"]) == 0 || form["DataOd"] == "" || form["DataDo"] == "" || form["Informacje"] == "")
                {
                    ViewBag.Info = "Musisz uzupełnić wszystkie pola oraz wybrać salę";
                    return View("DodajAwarieUWAGA");
                }

                int IdS = Convert.ToInt32(form["IdS"]);
                DateTime DataOd = Convert.ToDateTime(form["DataOd"]);
                DateTime DataDo = Convert.ToDateTime(form["DataDo"]);
                string Informacje = form["Informacje"];

                TimeSpan t = DataDo - DataOd;
                TimeSpan d = DataOd - DateTime.Now;
                if (d.TotalMinutes < 10)
                {
                    ViewBag.Info = "Awarie należy dodawać minimum 10 minut wcześniej";
                    return View("DodajAwarieUWAGA");
                }
                else if (t.TotalMinutes < 30)
                {
                    ViewBag.Info = "Minimalny czas Awari to 5 minut";
                    return View("DodajAwarieUWAGA");
                }
                else if (t.TotalMinutes > 600)
                {
                    ViewBag.Info = "Maksymalny czas Rezerwacji to 10 godzin";
                    return View("DodajAwarieUWAGA");
                }
                else if (DataOd.Hour < 8 || DataDo.Hour > 18 || (DataDo.Hour == 18 && DataDo.Minute > 0))
                {
                    ViewBag.Info = "Pracujemy w godzinach od 8 do 18";
                    return View("DodajAwarieUWAGA");
                }
                else
                {
                    BazaDanych baza = new BazaDanych();
                    baza.Polaczenie.Open();
                    SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Rezerwacja] WHERE [IdSala] = " + IdS.ToString() + " AND [DataOd] <= '" + DataDo.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [DataDo] >= '" + DataOd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    if (r.Read())
                    {
                        r.Close();
                        baza.Polaczenie.Close();
                        ViewBag.Info = "Isnieje rezerwacja na tą sale w tym czasie";
                        return View("DodajAwarieUWAGA");
                    }
                    r.Close();
                    r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Awaria] WHERE [IdSala] = " + IdS.ToString() + " AND [DataOd] <= '" + DataDo.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [DataDo] >= '" + DataOd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    if (r.Read())
                    {
                        r.Close();
                        baza.Polaczenie.Close();
                        ViewBag.Info = "Isnieje awaria tej sali w tym czasie";
                        return View("DodajAwarieUWAGA");
                    }
                    r.Close();
                    baza.Wykonaj("INSERT INTO [srskBaza].[dbo].[Awaria] ([IdSala], [DataOd], [DataDo], [Informacje]) VALUES(" + IdS.ToString() + ", '" + DataOd.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DataDo.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + Informacje + "')");
                    baza.Polaczenie.Close();
                    return RedirectToAction("Awarie", "Pracownik");
                }
            }
            else
            {
                return RedirectToAction("Informacje", "Konto");
            }
        }
    }
}
