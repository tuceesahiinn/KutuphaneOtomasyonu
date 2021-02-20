using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var degerler = db.Yazar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Yazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.Yazar.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.Yazar.Find(id);
            db.Yazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yazar = db.Yazar.Find(id);
            return View("YazarGetir", yazar);
        }
        public ActionResult YazarGüncelle(Yazar p)
        {
            var yzr = db.Yazar.Find(p.Id);
            yzr.Ad = p.Ad;
            yzr.Soyad = p.Soyad;
            yzr.Hakkında = p.Hakkında;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.Kitap.Where(x => x.Yazar == id).ToList();
            var yzrAd = db.Yazar.Where(y => y.Id == id).Select(z => z.Ad + " " +z.Soyad).FirstOrDefault();
            ViewBag.y1 = yzrAd;
            return View(yazar);
        }
    }
}