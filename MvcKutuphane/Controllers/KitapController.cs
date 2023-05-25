using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap

        KutuphaneDBEntitiesLast db = new KutuphaneDBEntitiesLast();
        public ActionResult KitapIndex(string p)
        {
            var kitap = from k in db.TBLKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitap = kitap.Where(m => m.Ad.Contains(p));
            }
            //var kitap = db.TBLKitap.ToList();
            return View(kitap.ToList());
        }

        [HttpGet]
        public ActionResult KtpEkleIndex()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KtpEkleIndex(TBLKitap ktp)
        {
            var ktg = db.TBLKategory.Where(k => k.Id == ktp.TBLKategory.Id).FirstOrDefault();
            var yzr = db.TBLYazarlar.Where(k => k.Id == ktp.TBLYazarlar.Id).FirstOrDefault();
            ktp.TBLKategory = ktg;
            ktp.TBLYazarlar = yzr;
            db.TBLKitap.Add(ktp);
            db.SaveChanges();
            return RedirectToAction("KitapIndex");
            
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKitap.Find(id);
            db.TBLKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("KitapIndex");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktpp = db.TBLKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktpp);
        }

        public ActionResult KitapGuncelle(TBLKitap tbktp)
        {
            var kitap = db.TBLKitap.Find(tbktp.Id);
            kitap.Ad = tbktp.Ad;
            kitap.Basimyill = tbktp.Basimyill;
            kitap.Sayfa = tbktp.Sayfa;
            kitap.Yayınevi = tbktp.Yayınevi;
            var ktgr = db.TBLKategory.Where(k => k.Id == tbktp.TBLKategory.Id).FirstOrDefault();
            var yzr = db.TBLYazarlar.Where(y => y.Id == tbktp.TBLYazarlar.Id).FirstOrDefault();
            kitap.Kategory = ktgr.Id;
            kitap.Yazar = yzr.Id;
            db.SaveChanges();
            return RedirectToAction("KitapIndex");
        }

      
    }
}