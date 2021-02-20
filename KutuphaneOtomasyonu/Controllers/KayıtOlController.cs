using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KayıtOlController : Controller
    {
        // GET: KayıtOl
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();

        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(Uyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayıt");
            }
            db.Uyeler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}