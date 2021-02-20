using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var degerler = db.Kategori.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori ktg)
        {
            db.Kategori.Add(ktg);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategori.Find(id);
            //db.Kategori.Remove(kategori);
            kategori.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategori.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGüncelle(Kategori p)
        {
            var ktg = db.Kategori.Find(p.Id);
            ktg.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}