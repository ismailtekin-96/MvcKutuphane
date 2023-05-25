using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        KutuphaneDBEntitiesLast db = new KutuphaneDBEntitiesLast();
        public ActionResult UyeIndex(int sayfa =1)
        {
            //var degerler = db.TBLUyeler.ToList();
            var degerler = db.TBLUyeler.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkleIndex() // ödünç verme kısmında abi
        {

            return View();
        }
        [HttpPost]
        public ActionResult UyeEkleIndex(TBLUyeler uye) // o ekranı ac
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkleIndex");
            }
            db.TBLUyeler.Add(uye);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUyeler.Find(id);
            db.TBLUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("UyeIndex");
        }
        public ActionResult UyeGetirIndex(int id)
        {
            var uyegncll = db.TBLUyeler.Find(id);
            return View("UyeGetirIndex", uyegncll);
        }

        public ActionResult UyeGuncelle(TBLUyeler uye)
        {
            var uyee = db.TBLUyeler.Find(uye.Id);
            uyee.Ad = uye.Ad;
            uyee.Soyad = uye.Soyad;
            uyee.Mail = uye.Mail;
            uyee.Kullaniciadi = uye.Kullaniciadi;
            uyee.Sifre = uye.Sifre;
            uyee.Okul= uye.Okul;
            uyee.Telefon = uye.Telefon;
            uyee.Fotograf = uye.Fotograf;
            db.SaveChanges();
            return RedirectToAction("UyeIndex");
        }
    }
}