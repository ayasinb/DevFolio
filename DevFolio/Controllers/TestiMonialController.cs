using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class TestiMonialController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
        public ActionResult TestiMonialList()
        {
            var values = db.TblTestiMonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(TblTestiMonial p)
        {
            db.TblTestiMonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("TestiMonialList");
        }

        public ActionResult DeleteTestiMonial(int id)
        {
            var value = db.TblTestiMonial.Find(id);
            db.TblTestiMonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestiMonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestiMonial(int id)
        {
            var value = db.TblTestiMonial.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestiMonial(TblTestiMonial p)
        {
            var value = db.TblTestiMonial.Find(p.TestiMonialID);
            value.TestiMonialNameSurname = p.TestiMonialNameSurname;
            value.TestiMonialDescription = p.TestiMonialDescription;
<<<<<<< HEAD
            value.TestiMonialImageURL = p.TestiMonialImageURL;
=======
>>>>>>> c481837dab3600e01ee40f7a6a2613662513de6c
            db.SaveChanges();
            return RedirectToAction("TestiMonialList");
        }
    }
}