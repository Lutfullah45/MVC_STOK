using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using MvcStok.Models.Entity;

namespace MVC_1.Controllers
{
    public class MüşteriController : Controller
    {
        // GET: Müşteri
        MVCdbStokEntities db = new MVCdbStokEntities(); 
        public ActionResult Index()
        {
            var degerler = db.M_Table_1.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(M_Table_1 p2)
        {
            db.M_Table_1.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var müşteri=db.M_Table_1.Find(id);
            db.M_Table_1.Remove(müşteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus=db.M_Table_1.Find(id);
            return View("MusteriGetir", mus);
            
        }
        public ActionResult Guncelle(M_Table_1 p1)
        {
            var p = db.M_Table_1.Find(p1.MUSTERIID);
            p.MUSTERIAD = p1.MUSTERIAD;
            p.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}