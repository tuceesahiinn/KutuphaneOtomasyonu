using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonu.Models.Entity;

namespace KutuphaneOtomasyonu.Controllers
{
    public class İşlemController : Controller
    {
        // GET: İşlem
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        public ActionResult Index()
        {
            var degerler = db.Hareket.Where(x => x.IslemDurum == true).ToList();
            return View(degerler);
        }
    }
}