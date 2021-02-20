using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace KutuphaneOtomasyonu.Controllers
{
    public class ÜyeController : Controller
    {
        // GET: Üye
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Uyeler.ToList();
            var degerler = db.Uyeler.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ÜyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÜyeEkle(Uyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("ÜyeEkle");
            }
            db.Uyeler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult ÜyeSil(int id)
        {
            var uye = db.Uyeler.Find(id);
            db.Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeGetir(int id)
        {
            var uye = db.Uyeler.Find(id);
            return View("ÜyeGetir", uye);
        }
        public ActionResult ÜyeGüncelle(Uyeler p)
        {
            var uye = db.Uyeler.Find(p.Id);
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.Mail = p.Mail;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Sifre = p.Sifre;
            uye.Fotograf = p.Fotograf;
            uye.Telefon = p.Telefon;
            uye.Okul = p.Okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeGeçmiş(int id)
        {
            var gecmis = db.Hareket.Where(x => x.Uye == id).ToList();
            var uyeAd = db.Uyeler.Where(y => y.Id == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.k1 = uyeAd;
            return View(gecmis);
        }
    }
}