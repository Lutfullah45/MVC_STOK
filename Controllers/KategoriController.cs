using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MVC_1.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCdbStokEntities db= new MVCdbStokEntities();

        public ActionResult Index()
        {
            var degerler = db.S_Table_1.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View(); 
        }
        
        [HttpPost]
        public ActionResult YeniKAtegori(S_Table_1 p1) {
            if (!ModelState.IsValid)
            {
                return View("YeniKAtegori");
            }
            db.S_Table_1.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }  
        public ActionResult SIL(int id)
        {
            var kategori= db.S_Table_1.Find(id);    
            db.S_Table_1.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.S_Table_1.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult GUNCELLE(S_Table_1 p1)
        {
            var ktg = db.S_Table_1.Find(p1.KATAGORIID);
            ktg.KATAGORIAD=p1.KATAGORIAD;
            db.SaveChanges();
            return RedirectToAction ("Index");  
        }
       
    }
}