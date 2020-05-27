using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USportsNews.Models.Entity;

namespace USportsNews.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa

        USportsNewsEntities db = new USportsNewsEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        // Ana Sayfaya veri tabanından verilerin daha kolay getirilmesi için Partial View'ler kullanılmıştır. 
        // Sorgu işlemleri Linq sorguları ile sağlanmıştır

        public PartialViewResult SonEklenenHaberler()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Take(5).ToList();
            return PartialView(habers);
        }
        // Sliderda en son eklenen haber için ; .ToList yapılmasının sebebi verinin IEnumerable olarak gelmesi 
        public PartialViewResult Slider()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Take(1).ToList();
            return PartialView(habers);
        }

        public PartialViewResult Slideriki()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m=>m.Slider=="Evet").Skip(1).Take(2).ToList();
            return PartialView(habers);
        }

        public PartialViewResult SagSlider()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Skip(3).Take(1).ToList();
            return PartialView(habers);
        }
        public PartialViewResult SagSlideralt()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Skip(4).Take(1).ToList();
            return PartialView(habers);
        }

        public PartialViewResult OrtakSol()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Skip(5).Take(3).ToList();
            return PartialView(habers);
        }

        public PartialViewResult OrtakSag()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.Slider == "Evet").Skip(8).Take(3).ToList();
            return PartialView(habers);
        }

        // Slidera eklenmemiş olan haberlerin kategoriler halinde listelenmesi 

          // Futbol kategorisinde bulunan üst sıradaki haberlerin listelenmesi için
        public PartialViewResult FutbolUst()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m=>m.KategoriID==1).Where( m => m.Slider == "Hayır").Take(4).ToList();
            return PartialView(habers);
        }
        public PartialViewResult FutbolAlt()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.KategoriID == 1).Where(m => m.Slider == "Hayır").Skip(4).Take(4).ToList();
            return PartialView(habers);
        }

        public PartialViewResult Basketbolust()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.KategoriID == 2).Take(4).ToList();
            return PartialView(habers);
        }
        public PartialViewResult Basketbolalt()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.KategoriID == 2).Skip(4).Take(4).ToList();
            return PartialView(habers);
        }

        public PartialViewResult DigerSporlarUst()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.KategoriID > 2).Take(4).ToList();
            return PartialView(habers);
        }

        public PartialViewResult DigerSporlarAlt()
        {
            List<Tbl_Haber> habers = db.Tbl_Haber.ToList().OrderByDescending(m => m.HaberID).Where(m => m.KategoriID > 2).Skip(4).Take(4).ToList();
            return PartialView(habers);
        }

        //public ActionResult Takimlar(String takımadi)
        //{
        //    var haberler = db.Tbl_Haber.Find(takımadi);
          
        //    return View("Takımlar", haberler);
        //}

        //public ActionResult TakimHabeler(Tbl_Haber p1)
        //{
        //    var haber = db.Tbl_Haber.Find(p1.Etiket);
        //    haber.HaberID = p1.HaberID;
        //    db.SaveChanges();
        //    return RedirectToAction("Takımlar");
        //}
    }
}