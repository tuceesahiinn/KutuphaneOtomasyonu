using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Kitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.Ad.Contains(p));
            }
            //var kitaplar = db.Kitap.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad+' '+i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitap p)
        {
            var ktg = db.Kategori.Where(k => k.Id == p.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(k => k.Id == p.Yazar1.Id).FirstOrDefault();
            p.Kategori1 = ktg;
            p.Yazar1 = yzr;
            db.Kitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.Kitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGüncelle(Kitap p)
        {
            var ktp = db.Kitap.Find(p.Id);
            ktp.Ad = p.Ad;
            ktp.BasımYılı = p.BasımYılı;
            ktp.SayfaSayisi = p.SayfaSayisi;
            ktp.YayınEvi = p.YayınEvi;
            ktp.Durum = true;
            var ktg = db.Kategori.Where(k => k.Id == p.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(k => k.Id == p.Yazar1.Id).FirstOrDefault();
            ktp.Kategori = ktg.Id;
            ktp.Yazar = yzr.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}