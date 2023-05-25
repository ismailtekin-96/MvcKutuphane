using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {

        KutuphaneDBEntitiesLast db = new KutuphaneDBEntitiesLast();
 
        //public ActionResult OduncIndex()
        //{
        //    return View();
        //}

        // GET: Odunc
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHareketler hareket) 
        {
            //TBLHareketler hareket = new TBLHareketler();
            ////hareket.Id = 5;
            //hareket.Personel = 2;
            //hareket.Uye = 4;
            //hareket.Kitap =4;
            //hareket.AlisTarihi = new DateTime();
            //hareket.IadeTarihi = new DateTime();

            try
            {
                //db.Entry(hareket).State = EntityState.Modified;
                //db.Entry(hareket).State = EntityState.Deleted;
                db.Entry(hareket).State = EntityState.Added;
                //db.TBLHareketler.(hareket);
                db.SaveChanges();
                return View();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View();
            }
        }


    }
}