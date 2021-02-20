using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Timers;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var deger1 = db.Uyeler.Count();
            var deger2 = db.Kitap.Count();
            var deger3 = db.Kitap.Where(x => x.Durum == false).Count();
            var deger4 = db.Ceza.Sum(x => x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult HavaDurum()
        {
            return View();
        }
        public ActionResult HavaDurumKartı()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FotoğrafYükle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/web2/Galeri/"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.Kitap.Count();
            var deger2 = db.Uyeler.Count();
            var deger3 = db.Ceza.Sum(x=>x.Para);
            var deger4 = db.Kitap.Where(x=>x.Durum==false).Count();
            var deger5 = db.Kategori.Count();
            var deger6 = db.Hareket.GroupBy(x => x.Uye).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger7 = db.Hareket.GroupBy(x => x.Kitap).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger8 = db.EnFazlaKitabıOlanYazar().FirstOrDefault();
            var deger9 = db.Kitap.GroupBy(x => x.YayınEvi).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger10 = db.Hareket.GroupBy(x => x.Personel).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger11 = db.Iletisim.Count();
            var deger12 = db.Hareket.Where(x => x.AlisTarihi == DateTime.Today).Select(c => c.Kitap).Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            return View();
        }
    }
}