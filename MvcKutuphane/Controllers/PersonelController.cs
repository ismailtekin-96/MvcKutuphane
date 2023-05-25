using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneDBEntitiesLast db = new KutuphaneDBEntitiesLast();
        public ActionResult PersonelIndex()
        {
            var degerler = db.TBLPersonel.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkleIndex()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkleIndex(TBLPersonel prsnl)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkleIndex");
            }
            db.TBLPersonel.Add(prsnl);
            db.SaveChanges();
            return View();
        }

        public ActionResult PersonelSil(int id)
        {
            var person = db.TBLPersonel.Find(id);
            db.TBLPersonel.Remove(person);
            db.SaveChanges();
            return RedirectToAction("PersonelIndex");
        }
        public ActionResult PersonelGetirIndex(int id)
        {
            var prsnlgncll = db.TBLPersonel.Find(id);
            return View("PersonelGetirIndex", prsnlgncll);
        }

        public ActionResult PersonelGuncelle(TBLPersonel pr)
        {
            var prs = db.TBLPersonel.Find(pr.Id);
            prs.Personel = pr.Personel;
            db.SaveChanges();
            return RedirectToAction("PersonelIndex");
        }
    }
}