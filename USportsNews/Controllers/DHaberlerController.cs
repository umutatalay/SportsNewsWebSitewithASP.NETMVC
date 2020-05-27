using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USportsNews.Models.Entity;
namespace USportsNews.Controllers
{
    public class DHaberlerController : Controller
    {
        // GET: DHaberler
        USportsNewsEntities db = new USportsNewsEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HaberleriListele()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.KategoriID > 3).ToList();
            return PartialView(habers);
        }

        // Haberin listelenmesi için oluşturulan sayfa hangi haberin listeleneceğinin anlaşılması için haberid ye denk gelcek bir parametre alır.
        public ActionResult Haber(int id)
        {

            var haber = db.Tbl_Haber.Find(id);
            return View("Haber", haber);

        }
        public ActionResult Haberler(Tbl_Haber p1)
        {
            var haber = db.Tbl_Haber.Find(p1.HaberID);
            haber.HaberID = p1.HaberID;
            db.SaveChanges();
            return RedirectToAction("Haber");
        }

        // Bir haber açıldığı zaman alt kısımda kullanıcıya öneri olarak gelecek haberleri listeyen kısım
        public PartialViewResult HaberAltı()
        {

            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Skip(7).Take(6).ToList();
            return PartialView(habers);
        }
    }
}