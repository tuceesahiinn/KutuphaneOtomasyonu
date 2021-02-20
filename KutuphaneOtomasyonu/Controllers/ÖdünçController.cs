using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class ÖdünçController : Controller
    {
        // GET: Ödünç
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var degerler = db.Hareket.Where(x=>x.IslemDurum==false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ÖdünçVer()
        {
            List<SelectListItem> deger1 = (from x in db.Uyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad +" "+ x.Soyad,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in db.Kitap.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in db.Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personel1,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult ÖdünçVer(Hareket hrk)
        {
            var d1 = db.Uyeler.Where(x => x.Id == hrk.Uyeler.Id).FirstOrDefault();
            var d2 = db.Kitap.Where(x => x.Id == hrk.Kitap1.Id).FirstOrDefault();
            var d3 = db.Personel.Where(x => x.Id == hrk.Personel1.Id).FirstOrDefault();
            hrk.Uyeler = d1;
            hrk.Kitap1 = d2;
            hrk.Personel1 = d3;
            db.Hareket.Add(hrk);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        public ActionResult Ödünçİade(Hareket p)
        {
            var odn = db.Hareket.Find(p.Id);
            DateTime d1 = DateTime.Parse(odn.IadeTarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Ödünçİade", odn);
        }
        public ActionResult ÖdünçGüncelle(Hareket p)
        {
            var hrk = db.Hareket.Find(p.Id);
            hrk.TeslimTarihi = p.TeslimTarihi;
            hrk.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}