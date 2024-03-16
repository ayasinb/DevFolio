using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;


namespace DevFolio.Controllers
{
    public class AboutController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
        public ActionResult AboutList()
        {
            ViewBag.aboutcount = db.TblAbout.Count();
            var values = db.TblAbout.ToList();
            return View(values);
        } 
        [HttpGet]
        public ActionResult CreateAbout()
        {
            var countabout = db.TblAbout.Count();
            if(countabout>0)
            {
                ViewBag.countabout = countabout;
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(TblAbout p)
        {
            var countabout = db.TblAbout.Count();
            if (countabout > 0)
            {
                return RedirectToAction("AboutList");
            }
            else
            {
                db.TblAbout.Add(p);
                db.SaveChanges();
            }

            return RedirectToAction("AboutList");
        }
        
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var values = db.TblAbout.Find(p.AboutId);
            values.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}