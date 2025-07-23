using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MvcStok.Models.Entity;

namespace MVC_1.Controllers
{
    public class ÜrunController : Controller
    {
        // GET: Ürun
      MVCdbStokEntities db = new MVCdbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.U_Table_1.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler =(from i in db.S_Table_1.ToList()
                                                select new SelectListItem
                                                { 
                                                Text=i.KATAGORIAD,
                                                Value= i.KATAGORIID.ToString()
                                                }).ToList();
            ViewBag.dgr=degerler;

            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(U_Table_1 p3)
        {
            var ktgr = db.S_Table_1.Where(i => i.KATAGORIID == p3.S_Table_1.KATAGORIID).FirstOrDefault();
            p3.S_Table_1 = ktgr;
            db.U_Table_1.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.U_Table_1.Find(id);
            db.U_Table_1.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult yeni(int id)
        {
            var urn = db.U_Table_1.Find(id);
            return View("yeni", urn);
        }
        [HttpPost]
        public ActionResult Guncelle(U_Table_1 p1)
        {
            var urnu =db.U_Table_1.Where((i) => i.URUNID == p1.URUNID).FirstOrDefault();
            urnu.URUNAD=p1.URUNAD;
            urnu.MARKA=p1.MARKA;
            urnu.STOK=p1.STOK;
            urnu.FİYAT=p1.FİYAT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}