using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USportsNews.Models.Entity;
namespace USportsNews.Controllers
{
    public class YazarController : Controller
    {
        USportsNewsEntities db = new USportsNewsEntities();
        // GET: Yazar
        public ActionResult YazarPanel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Giris(FormCollection fc)
        {
            foreach (var deger in db.Tbl_Yazar)
            {
                String epa = deger.YazarEposta;
                String epaiki = fc["eposta"];
                String sifredb = deger.YazarParola;
                String sifregelen = fc["sifre"];
                if (epa == epaiki && sifredb == sifregelen)
                {
                    return Redirect("YazarPanel");
                }

            }

            return View();
        }

        public ActionResult Giris()
        {

            return View();
        }

        [HttpPost]
        public ActionResult HaberEkle(Tbl_Haber haber)
        {
            var kategoriler = db.Tbl_Kategori.Where(m => m.KategoriID == haber.Tbl_Kategori.KategoriID).FirstOrDefault();
            haber.Tbl_Kategori = kategoriler;
            db.Tbl_Haber.Add(haber);
            db.SaveChanges();
            return RedirectToAction("HaberListele");
        }
        [HttpGet]
        public ActionResult HaberEkle()
        {
            List<SelectListItem> kgetir = (from i in db.Tbl_Kategori.ToList() select new SelectListItem { Text = i.KategoriAdi, Value = i.KategoriID.ToString() }).ToList();
            ViewBag.kg = kgetir;
            return View();
        }


        public ActionResult YazarHaberListele()
        {
            var haberler = db.Tbl_Haber.ToList();
            return View(haberler);
        }

        public ActionResult HaberSil(int id)
        {
            var haber = db.Tbl_Haber.Find(id);
            db.Tbl_Haber.Remove(haber);
            db.SaveChanges();
            return RedirectToAction("HaberListele");
        }


        public ActionResult HaberiGuncelle(int id)
        {
            var haber = db.Tbl_Haber.Find(id);
            return View("HaberiGuncelle", haber);
        }

        public ActionResult HGuncelle(Tbl_Haber p1, FormCollection fc)
        {
            var haber = db.Tbl_Haber.Find(p1.HaberID);
            haber.HaberBaslik = p1.HaberBaslik;
            haber.HaberGorsel = p1.HaberGorsel;
            haber.HaberIcerik = p1.HaberIcerik;
            haber.HaberOzet = p1.HaberOzet;
            haber.HaberTarih = p1.HaberTarih;
            haber.KategoriID = p1.KategoriID;

            db.SaveChanges();
            return RedirectToAction("HaberListele");
        }
    }
}