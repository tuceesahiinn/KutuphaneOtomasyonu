using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;
using System.Web.Security;

namespace KutuphaneOtomasyonu.Controllers
{
    public class GirişYapController : Controller
    {
        // GET: GirişYap
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult GirişYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirişYap(Uyeler p)
        {
            var bilgiler = db.Uyeler.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                //TempData["Id"] = bilgiler.Id.ToString();
                //TempData["Ad"] = bilgiler.Ad.ToString();
                //TempData["Soyad"] = bilgiler.Soyad.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KullaniciAdi.ToString();
                //TempData["Şifre"] = bilgiler.Sifre.ToString();
                //TempData["Okul"] = bilgiler.Okul.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}