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
    public class RezerwacjaController : Controller
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

        //----------------------------------------------------- USUWANIE REZERWACJI -----------------------------------------------
        public ActionResult Usun(int id)
        {
            int l = Zalogowany();
            if(l > 0)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Rezerwacja] WHERE Id = " + id + ";");
                if(r.Read())
                {
                    if(l == 2 && r["IdKonto"].ToString() == HttpContext.Session.GetString("Id"))
                    {
                        int idk = Convert.ToInt32(r["IdKonto"]);
                        r.Close();
                        baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Rezerwacja] WHERE [Id] = " + id + ";");
                        baza.Polaczenie.Close();
                        return RedirectToAction("Informacje", "Konto");
                    }
                    else if(l == 2)
                    {
                        int idk = Convert.ToInt32(r["IdKonto"]);
                        r.Close();
                        baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Rezerwacja] WHERE [Id] = " + id + ";");
                        baza.Polaczenie.Close();
                        return RedirectToAction("Rezerwacje", "Pracownik");
                    }
                    else if(r["IdKonto"].ToString() == HttpContext.Session.GetString("Id"))
                    {
                        r.Close();
                        baza.Wykonaj("DELETE FROM [srskBaza].[dbo].[Rezerwacja] WHERE [Id] = " + id + ";");
                        baza.Polaczenie.Close();
                        return RedirectToAction("Informacje", "Konto");
                    }
                    else
                    {
                        baza.Polaczenie.Close();
                        return RedirectToAction("Informacje", "Konto");
                    }
                }
                else
                {
                    baza.Polaczenie.Close();
                    return RedirectToAction("Informacje", "Konto");
                }
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }



        //----------------------------------------------------- REZERWACJA -----------------------------------------------
        public ActionResult Rezerwacja()
        {
            if (Zalogowany() > 0)
            {
                RezerwacjaModel r = new RezerwacjaModel()
                {
                    Id = -1,
                    IdKonto = -1,
                    IdSala = -1,
                    DataOd = DateTime.Now,
                    DataDo = DateTime.Now
                };
                ViewBag.Info = "";
                return View(r);
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rezerwacja(RezerwacjaModel rezerwacja)
        {
            if (Zalogowany() > 0)
            {
                TimeSpan t = rezerwacja.DataDo - rezerwacja.DataOd;
                TimeSpan d = rezerwacja.DataOd - DateTime.Now;
                if (d.TotalMinutes < 120)
                {
                    ViewBag.Info = "Rezerwacji należy dokonać minimum 2 godziny wcześniej";
                    return View("Rezerwacja", rezerwacja);
                }
                else if (d.TotalDays > 30)
                {
                    ViewBag.Info = "Rezerwować można maksymalnie 30 dni do przodu";
                    return View("Rezerwacja", rezerwacja);
                }
                else if (t.TotalMinutes < 30)
                {
                    ViewBag.Info = "Minimalny czas Rezerwacji to 30 min";
                    return View("Rezerwacja", rezerwacja);
                }
                else if (t.TotalMinutes > 300)
                {
                    ViewBag.Info = "Maksymalny czas Rezerwacji to 5 godzin";
                    return View("Rezerwacja", rezerwacja);
                }
                else if (rezerwacja.DataOd.Hour < 8 || rezerwacja.DataDo.Hour > 18 || (rezerwacja.DataDo.Hour == 18 && rezerwacja.DataDo.Minute > 0))
                {
                    ViewBag.Info = "Rezerwacje dostępne od godziny 8 do 18";
                    return View("Rezerwacja", rezerwacja);
                }
                else
                {
                    return RedirectToAction("Budynki", "Rezerwacja", new { DataOd = rezerwacja.DataOd.ToString("yyyy-MM-dd HH:mm:ss"), DataDo = rezerwacja.DataDo.ToString("yyyy-MM-dd HH:mm:ss") });
                }
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }

        public ActionResult Budynki(string DataOd, string DataDo)
        {
            if (Zalogowany() > 0)
            {
                List<BudynekWybor> budynki = new List<BudynekWybor>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT Id, Symbol, Miasto, Adres, Pietra, Informacje, COUNT(NrSali) As IloscSal FROM (((SELECT S.NrSali, B.Id, B.Symbol, B.Miasto, B.Adres, B.Pietra, B.Informacje FROM [srskBaza].[dbo].[Sala] as S INNER JOIN [srskBaza].[dbo].[Budynek] as B ON S.IdBudynek=B.Id) EXCEPT (SELECT S.NrSali, B.Id, B.Symbol, B.Miasto, B.Adres, B.Pietra, B.Informacje FROM [srskBaza].[dbo].[Sala] as S INNER JOIN [srskBaza].[dbo].[Budynek] as B ON S.IdBudynek=B.Id RIGHT OUTER JOIN [srskBaza].[dbo].[Rezerwacja] as R ON R.IdSala=S.Id WHERE R.DataOd <= '" + DataDo + "' AND R.DataDo >= '" + DataOd + "')) EXCEPT (SELECT S.NrSali, B.Id, B.Symbol, B.Miasto, B.Adres, B.Pietra, B.Informacje FROM [srskBaza].[dbo].[Sala] as S INNER JOIN [srskBaza].[dbo].[Budynek] as B ON S.IdBudynek=B.Id RIGHT OUTER JOIN [srskBaza].[dbo].[Awaria] as A ON A.IdSala=S.Id WHERE A.DataOd <= '" + DataDo + "' AND A.DataDo >= '" + DataOd + "')) AS WykazBusynkow GROUP BY Id, Symbol, Miasto, Adres, Pietra, Informacje");
                while (r.Read())
                {
                    budynki.Add(new BudynekWybor()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Symbol = r["Symbol"].ToString(),
                        Miasto = r["Miasto"].ToString(),
                        Adres = r["Adres"].ToString(),
                        Pietra = Convert.ToInt32(r["Pietra"]),
                        Informacje = r["Informacje"].ToString(),
                        IloscSal = Convert.ToInt32(r["Iloscsal"])
                    }); ;
                }
                r.Close();
                baza.Polaczenie.Close();
                ViewBag.DataOd = DataOd;
                ViewBag.DataDo = DataDo;
                return View(budynki);
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }

        public ActionResult Sale(int IdB, string DataOd, string DataDo)
        {
            if (Zalogowany() > 0)
            {
                List<SalaModel> sale = new List<SalaModel>();
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT Id, IdBudynek, IloscMiejsc, Informacje, NrSali, Pietro FROM (((SELECT S.Id, S.IdBudynek, S.IloscMiejsc, S.Informacje, S.NrSali, S.Pietro FROM [srskBaza].[dbo].[Sala] as S INNER JOIN [srskBaza].[dbo].[Budynek] as B ON S.IdBudynek=B.Id WHERE B.Id = '"+ IdB.ToString() + "') EXCEPT (SELECT S.Id, S.IdBudynek, S.IloscMiejsc, S.Informacje, S.NrSali, S.Pietro FROM [srskBaza].[dbo].[Sala] as S INNER JOIN [srskBaza].[dbo].[Budynek] as B ON S.IdBudynek=B.Id RIGHT OUTER JOIN [srskBaza].[dbo].[Rezerwacja] as R ON R.IdSala=S.Id WHERE B.Id = '"+ IdB.ToString() + "' AND R.DataOd <= '"+ DataDo +"' AND R.DataDo >= '"+ DataOd +"')) EXCEPT (SELECT S.Id, S.IdBudynek, S.IloscMiejsc, S.Informacje, S.NrSali, S.Pietro FROM [srskBaza].[dbo].[Sala] as S INNER JOIN [srskBaza].[dbo].[Budynek] as B ON S.IdBudynek=B.Id RIGHT OUTER JOIN [srskBaza].[dbo].[Awaria] as A ON A.IdSala=S.Id WHERE B.Id = '"+ IdB.ToString() + "' AND A.DataOd <= '"+ DataDo +"' AND A.DataDo >= '"+ DataOd +"')) AS WykazSal GROUP BY Id, IdBudynek, IloscMiejsc, Informacje, NrSali, Pietro");
                while (r.Read())
                {
                    sale.Add(new SalaModel()
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        IdBudynek = Convert.ToInt32(r["IdBudynek"]),
                        IloscMiejsc = Convert.ToInt32(r["IloscMiejsc"]),
                        Informacje = r["Informacje"].ToString(),
                        NrSali = Convert.ToInt32(r["NrSali"]),
                        Pietro = Convert.ToInt32(r["Pietro"])
                    });
                }
                r.Close();
                baza.Polaczenie.Close();
                ViewBag.DataOd = DataOd;
                ViewBag.DataDo = DataDo;
                return View(sale);
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }

        public ActionResult RezerwowanieKoniec(int IdB, int IdS, string DataOd, string DataDo)
        {
            if (Zalogowany() > 0)
            {
                BazaDanych baza = new BazaDanych();
                baza.Polaczenie.Open();
                SqlDataReader r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Rezerwacja] WHERE [IdSala] = " + IdS.ToString() + " AND [DataOd] <= '" + DataDo + "' AND [DataDo] >= '" + DataOd + "'");
                if (r.Read())
                {
                    r.Close();
                    baza.Polaczenie.Close();
                    ViewBag.Info = "Wybrana sala nie jest już dostępna, wybierz inną";
                    return RedirectToAction("Sale", "Rezerwacja", new { IdB = IdB, DataOd = DataOd, DataDo = DataDo });
                }
                r.Close();
                r = baza.WykonajPobierz("SELECT * FROM [srskBaza].[dbo].[Awaria] WHERE [IdSala] = " + IdS.ToString() + " AND [DataOd] <= '" + DataDo + "' AND [DataDo] >= '" + DataOd + "'");
                if (r.Read())
                {
                    r.Close();
                    baza.Polaczenie.Close();
                    ViewBag.Info = "Wybrana sala nie jest już dostępna, wybierz inną";
                    return RedirectToAction("Sale", "Rezerwacja", new { IdB = IdB, DataOd = DataOd, DataDo = DataDo });
                }
                r.Close();
                baza.Wykonaj("INSERT INTO [srskBaza].[dbo].[Rezerwacja] ([IdSala], [IdKonto], [DataOd], [DataDo]) VALUES(" + IdS + ", " + HttpContext.Session.GetString("Id") + ", '" + DataOd + "', '" + DataDo + "')");
                baza.Polaczenie.Close();
                return View();
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }
    }
}
