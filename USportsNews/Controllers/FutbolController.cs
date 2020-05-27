using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USportsNews.Models.Entity;
namespace USportsNews.Controllers
{
    public class FutbolController : Controller
    {
        // GET: Futbol
        USportsNewsEntities db = new USportsNewsEntities();
        public ActionResult Index()
        {
            return View();
        }
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
        // Futbol Sayfasında bulanacak olan haberler gruplarının her biri ayrı ayrı PartialView olarak bölündü.
        // Linq sorguları kullanılarak istenilen veriler elde edildi ve bu veriler listede tutuluyor.
        // Slider Evet vaya Hayır diyerek sliderda eklenecek haberlerden mi yoksa eklenmeyecek haberlerden mi veri çekileceği belirleniyor.
        // Take ile kaç adet veri geleceği seçiliyor.
        // Skip ile baş kısımında lislenmesi gereken ama geçicelek verileri belirli eder.
        public PartialViewResult Sliderbir()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Where(m=>m.KategoriID==1).Take(1).ToList();
            return PartialView(habers);
        }
        public PartialViewResult Slideriki()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Where(m => m.KategoriID == 1).Skip(1).Take(2).ToList();
            return PartialView(habers);
        }

        public PartialViewResult OrtaKartlar()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Hayır").Where(m => m.KategoriID == 1).Take(4).ToList();
            return PartialView(habers);
        }
        public PartialViewResult Slideruc()
        {

            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Where(m => m.KategoriID == 1).Skip(3).Take(1).ToList();
            return PartialView(habers);
        }

        public PartialViewResult SolHaberler()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Hayır").Where(m => m.KategoriID == 1).Skip(4).Take(3).ToList();
            return PartialView(habers);
        }

        public PartialViewResult SagHaberler()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Hayır").Where(m => m.KategoriID == 1).Skip(7).Take(3).ToList();
            return PartialView(habers);
        }

        // Bir haber açıldığı zaman alt kısımda kullanıcıya öneri olarak gelecek haberleri listeyen kısım
        public PartialViewResult HaberAltı()
        {
            
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Skip(7).Take(6).ToList();
            return PartialView(habers);
        }
    }

    
}