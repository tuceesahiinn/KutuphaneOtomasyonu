using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"];
            var degerler = db.Uyeler.FirstOrDefault(z => z.Mail == uyeMail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(Uyeler p)
        {
            var kullanıcı = (string)Session["Mail"];
            var uye = db.Uyeler.FirstOrDefault(x => x.Mail == kullanıcı);
            uye.Sifre = p.Sifre;
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Fotograf = p.Fotograf;
            uye.Okul = p.Okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var kullanıcı = (string)Session["Mail"];
            var id = db.Uyeler.Where(x => x.Mail == kullanıcı.ToString()).Select(z => z.Id).FirstOrDefault();
            var degerler = db.Hareket.Where(x => x.Uye == id).ToList();
            return View(degerler);        
        }

        public ActionResult Duyurular()
        {
            var duyuruListesi = db.Duyuru.ToList();
            return View(duyuruListesi);
        }
        public ActionResult ÇıkışYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirişYap", "GirişYap"); 
        }
    }
}