using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        KutuphaneDBEntitiesLast db = new KutuphaneDBEntitiesLast();
        public ActionResult KategoriIndex()
        {
            var degerler = db.TBLKategory.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KtgEkleIndex()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult KtgEkleIndex(TBLKategory kategory)
        {
            db.TBLKategory.Add(kategory);
            db.SaveChanges();
            return View();
        }

        public ActionResult KtgrSil(int id  )
        {
            var kategori = db.TBLKategory.Find(id);
            db.TBLKategory.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
        public ActionResult KtgrGetirIndex(int id ) 
        {
            var ktgrgncll = db.TBLKategory.Find(id);
            return View("KtgrGetirIndex", ktgrgncll);
        }

        public ActionResult KategoriGuncelle(TBLKategory kt)
        {
            var ktg = db.TBLKategory.Find(kt.Id);
            ktg.Ad = kt.Ad;
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
    }
}