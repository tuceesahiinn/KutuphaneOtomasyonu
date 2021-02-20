using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;
namespace KutuphaneOtomasyonu.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var degerler = db.Personel.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personel.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.Personel.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGüncelle(Personel p)
        {
            var prs = db.Personel.Find(p.Id);
            prs.Personel1 = p.Personel1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}