using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;


namespace KutuphaneOtomasyonu.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesaj.Where(x=>x.Alici==uyeMail.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult GönderilenMesaj()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesaj.Where(x => x.Gonderen == uyeMail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj t)
        {
            var uyeMail= (string)Session["Mail"].ToString();
            t.Gonderen = uyeMail.ToString();
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesaj.Add(t);
            db.SaveChanges();
            return RedirectToAction("GönderilenMesaj","Mesaj");
        }
    }
}