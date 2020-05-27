using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USportsNews.Models.Entity;
namespace USportsNews.Controllers
{
    [ValidateInput(false)]
    public class AdminController : Controller
    {
        // GET: Admin
        USportsNewsEntities db = new USportsNewsEntities();
        //public String ka = "Umut";
        //public String sifrem = "Umut";
        // 28.IV.2020 düzenleme [Authorize]
        int adminid;


        //  Bilgilerin listelendiği bir profil sayfası için oluşturulmuştur aldığı ID parametresi ile 
        // istenilen kullanıcılın profilini listeliyor.
        // Bulunan kullanıcının verilerinin yazdırılabilmesi için View bag ile sayfaya gönderiliyor.
        public ActionResult AdminPanel(int id)
        {
            var adminbilgi = db.Tbl_Yazar.Find(id);
            ViewBag.id = id;
            ViewBag.isim = adminbilgi.YazarAdi;
            ViewBag.soyisim = adminbilgi.YazarSoyadi;
            ViewBag.telefon = adminbilgi.YazarTel;
            ViewBag.eposta = adminbilgi.YazarEposta;
            return View("AdminPanel", adminbilgi);
        }

        public ActionResult Adminprofil(Tbl_Yazar p1)
        {
            var aprofil = db.Tbl_Yazar.Find(p1);
            aprofil.YazarAdi = p1.YazarAdi;
            db.SaveChanges();
            return RedirectToAction("AdminPanel");
        }
        public ActionResult AdminP(Tbl_Admin p1)
        {
            var adminprofil = db.Tbl_Admin.Find(p1.AdminID);
            adminprofil.AdminAdi = p1.AdminAdi;
            db.SaveChanges();
            return RedirectToAction("AdminPanel");

        }
        public ActionResult AdminPaneli(int id)
        {
            var yazar = db.Tbl_Admin.Find(id);
            var degerler = db.Tbl_Yazar.ToList();
            return View("AdminPaneli",yazar);
        }
        [HttpPost]
        public ActionResult KategoriEkle(Tbl_Kategori k)
        {
            db.Tbl_Kategori.Add(k);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriEkle()
        {   
            return View();
        }

        // Panel'e girişin sağlanması 
        [HttpPost]
        public ActionResult Giris(FormCollection fc)
        {
            foreach (var deger in db.Tbl_Yazar)
            {
                String epa = deger.YazarEposta;
                String epaiki= fc["eposta"];
                String sifredb = deger.YazarParola;
                String sifregelen= fc["sifre"];
                if (epa==epaiki && sifredb==sifregelen)
                {
                    adminid = deger.YazarID;
                    return Redirect("AdminPanel/"+deger.YazarID); // Bu şekide gönderilmesindeki amaç kişinin profilinin listelenmesi
                                                                  // Kullanıcının ID'si parametre olarak gidecek.
                }
             
            }
            
            return View();
           
        }
        
        public ActionResult Giris()
        {
            
            return View();
        }
       
        // Kategorilerin listeleneceği sayfa
        public ActionResult KategoriIslemleri() 
        {
            var kategoriler = db.Tbl_Kategori.ToList();
            return View(kategoriler);
        }
        // Çalıştığında parametre olarak aldığı id'li kategoriyi siler, kendine özel bir View'i yoktur.
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriIslemleri");
        }
        // Kategorileri listele kısmından gelen id parametresi ile çalışır.  
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.Tbl_Kategori.Find(id);
            return View("KategoriGuncelle",kategori);
        }
        // Kategori güncelle sayfasında formdan gelen işlemleri yapar kendine özel bir View'i yoktur.
        public ActionResult KGuncelle(Tbl_Kategori p1)
        {
            var kategoriler = db.Tbl_Kategori.Find(p1.KategoriID);
            kategoriler.KategoriAdi = p1.KategoriAdi;
            db.SaveChanges();
            return RedirectToAction("KategoriIslemleri");
        }
        [HttpPost]
        public ActionResult HaberEkle(Tbl_Haber haber)
        {
             
        }

        //public ActionResult ResimEkle(Tbl_Haber haber)
        //{
        //    //Guid nesnesini benzersiz dosya adı oluşturmak için tanımladık ve Replace ile aradaki “-” işaretini atıp yan yana yazma işlemi yaptık.
        //    string DosyaAdi = Guid.NewGuid().ToString();
        //    //Kaydetceğimiz resmin uzantısını aldık.
        //    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
        //    string TamYolYeri = "~/Pictures" + DosyaAdi + uzanti;
        //    //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
        //    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
        //    haber.HaberGorsel = DosyaAdi + uzanti;
        //    db.Tbl_Haber.Add(haber);


        //    db.SaveChanges();
        //    return RedirectToAction("HaberListele");
        //}

        [HttpGet]
        public ActionResult HaberEkle()
        {
            //var haber = db.Tbl_Haber.Find(id);
            
            List<SelectListItem> kgetir = (from i in db.Tbl_Kategori.ToList() select new SelectListItem { Text = i.KategoriAdi, Value = i.KategoriID.ToString() }).ToList();
            ViewBag.kg = kgetir;
            ViewBag.yid = adminid;
            //ViewBag.adminid = id;
           return View();
        }

        // Habelerin listelenmesi için bu viewdan silme ve güncelle işlemleri de yapılabilecek.
        public ActionResult HaberListele()
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

        public ActionResult HGuncelle(Tbl_Haber p1,FormCollection fc)
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

        [HttpPost]
        public ActionResult YazarEkle(Tbl_Yazar y)
        {
            db.Tbl_Yazar.Add(y);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarEkle()
        {
            return View();
        }

        //public ActionResult EtiketIslemleri()
        //{
        //    var etiketler = db.Tbl_Tag.ToList();
        //    return View(etiketler);
        //}


        //public ActionResult EtiketSil(int id)
        //{
        //    var etiket = db.Tbl_Tag.Find(id);
        //    db.Tbl_Tag.Remove(etiket);
        //    db.SaveChanges();
        //    return RedirectToAction("EtiketIslemleri");
        //}

        //public ActionResult EtiketGuncelle(int id)
        //{
        //    var etiket = db.Tbl_Tag.Find(id);
        //    return View("EtiketGuncelle", etiket);
        //}

        //public ActionResult EGuncelle(Tbl_Tag p1)
        //{
        //    var etiket = db.Tbl_Tag.Find(p1.TagID);
        //    etiket.TagAdi = p1.TagAdi;
        //    db.SaveChanges();
        //    return RedirectToAction("EtiketIslemleri");
        //}

        //[HttpPost]
        //public ActionResult EtiketEkle(Tbl_Tag e)
        //{

        //    db.Tbl_Tag.Add(e);
        //    db.SaveChanges();

        //    return View();
        //}

        //public ActionResult EtiketEkle()
        //{

        //    return View();
        //}
        //[HttpGet]
        //public ActionResult ResimEkle()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ResimEkle(Image ImageModel)
        //{
        //    string filename=Path.GetFileNameWithoutExtension(ImageModel.);
        //    filename = Path.GetFileNameWithoutExtension(ImageModel.);


        //    return View();
        //}
        //public ActionResult ResimEkle()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ResimEkle(HttpPostedFileBase yuklenecekresim)
        //{ 
        //    Tbl_Haber haber = new Tbl_Haber();
        //    haber.HaberGorsel = Fonksiyon.Fonksiyon.ImageUpload(yuklenecekresim, "~/Pictures", new System.Drawing.Size(100, 100));
        //    db.Tbl_Haber.Add(haber);
        //    return View();
        //}
    }

   

    //public ActionResult ResimEkle(Tbl_Haber haber)
    //{
    //    //Guid nesnesini benzersiz dosya adı oluşturmak için tanımladık ve Replace ile aradaki “-” işaretini atıp yan yana yazma işlemi yaptık.
    //    string DosyaAdi = Guid.NewGuid().ToString();
    //    //Kaydetceğimiz resmin uzantısını aldık.
    //    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
    //    string TamYolYeri = "~/Pictures" + DosyaAdi + uzanti;
    //    //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
    //    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
    //    haber.HaberGorsel = DosyaAdi + uzanti;
    //    db.Tbl_Haber.Add(haber);


    //    db.SaveChanges();
    //    return RedirectToAction("HaberListele");
    //}

    
}