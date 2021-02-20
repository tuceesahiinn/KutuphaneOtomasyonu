using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var degerler = db.Duyuru.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(Duyuru p)
        {
            db.Duyuru.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.Duyuru.Find(id);
            db.Duyuru.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(Duyuru p)
        {
            var duyuru = db.Duyuru.Find(p.Id);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGüncelle(Duyuru t)
        {
            var duyuru = db.Duyuru.Find(t.Id);
            duyuru.Kategori = t.Kategori;
            duyuru.Icerik = t.Icerik;
            duyuru.Tarih = t.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}