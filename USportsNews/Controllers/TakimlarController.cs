using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USportsNews.Models.Entity;
namespace USportsNews.Controllers
{
    public class TakimlarController : Controller
    {
        // GET: Takimlar
        USportsNewsEntities db = new USportsNewsEntities();
        public ActionResult Index()
        {
            return View();
        }

        // Bu kısım AnaSayfada bulunan takım adları, olimpiyat gibi etiket ile tanımlanmış haberlerin filtrenmiş olarak yazdırılmasını sağlar.

        public ActionResult Galatasaray()
        {
            var takımlar = db.Tbl_Haber.Where(m=>m.Etiket.Contains("Galatasaray")).ToList();
            return View(takımlar);   
        }
        public ActionResult Fenerbahçe()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Fenerbahçe")).ToList();
            return View(takımlar);
        }
        public ActionResult Beşiktaş()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Beşiktaş")).ToList();
            return View(takımlar);
        }
        public ActionResult Trabzonspor()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Trabzonspor")).ToList();
            return View(takımlar);
        }
        public ActionResult Basaksehir()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Başakşehir")).ToList();
            return View(takımlar);
        }
        public ActionResult Sivasspor()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("sivas")).ToList();
            return View(takımlar);
        }
        public ActionResult Alanyaspor()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Alanya")).ToList();
            return View(takımlar);
        }
        public ActionResult Gaziantep()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Gazi")).ToList();
            return View(takımlar);
        }
        public ActionResult Denizli()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Denizli")).ToList();
            return View(takımlar);
        }
        public ActionResult Antalyaspor()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Antalya")).ToList();
            return View(takımlar);
        }
        public ActionResult Genclerbirligi()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("genclerbirliği")).ToList();
            return View(takımlar);
        }
        public ActionResult Konyaspor()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("konya")).ToList();
            return View(takımlar);
        }
        public ActionResult Kasimpasa()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("Kasimpasa")).ToList();
            return View(takımlar);
        }
        public ActionResult Ankaragucu()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("gücü")).ToList();
            return View(takımlar);
        }
        public ActionResult Rize()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("rize")).ToList();
            return View(takımlar);
        }
        public ActionResult Malatya()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("malatya")).ToList();
            return View(takımlar);
        }
        public ActionResult Kayseri()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("kayseri")).ToList();
            return View(takımlar);
        }
        public ActionResult Goztepe()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("göztepe")).ToList();
            return View(takımlar);
        }

        public ActionResult Olimpiyat()
        {
            var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("olimpiyat")).ToList();
            return View(takımlar);
        }

        public ActionResult SampiyonlarLigi()
        {
            
                var takımlar = db.Tbl_Haber.Where(m => m.Etiket.Contains("şampiyonlar ligi")).ToList();
                return View(takımlar);
            
        }
    }
}