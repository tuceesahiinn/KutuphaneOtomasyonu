using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;
using KutuphaneOtomasyonu.Models.Sınıflar;

namespace KutuphaneOtomasyonu.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Kitap.ToList();
            cs.Deger2 = db.Hakkımızda.ToList();
            //var degerler = db.Kitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Iletisim t)
        {
            db.Iletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}