using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneDBEntitiesLast db = new KutuphaneDBEntitiesLast();
        public ActionResult YazarIndex()
        {
            var degerler = db.TBLYazarlar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYazarlar yazar)
        {
            db.TBLYazarlar.Add(yazar);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil( int id)
        {
            var yazar = db.TBLYazarlar.Find(id);
            db.TBLYazarlar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("YazarIndex");
        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYazarlar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBLYazarlar yg)
        {
            var yzrg = db.TBLYazarlar.Find(yg.Id);
            yzrg.Ad = yg.Ad;
            yzrg.Soyad = yg.Soyad;
            yzrg.Detay = yg.Detay;
            yzrg.Ad = yg.Ad;
            db.SaveChanges();
            return RedirectToAction("YazarIndex");
        }
    }
}