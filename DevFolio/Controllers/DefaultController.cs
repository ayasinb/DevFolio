using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
   
    public class DefaultController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {

            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {

            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.OrderBy(x => x.SkillTitle).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestiMonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAddress()
        {
            var values = db.TblAdress.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMedia()
        {
            var values = db.TblSocialMedia.Where(x => x.SocialMediaStatus == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProject()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            ViewBag.show = false;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult PartialContact(TblContact p)
        {
            p.ContactIsRead = false;
            p.ContactSendMessageDate = DateTime.Now;
            db.TblContact.Add(p);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.show = true;
            return PartialView("PartialContact");
        }

        public PartialViewResult PartialStatistic()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.testimonialCount = db.TblTestiMonial.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.ServiceCount = db.TblService.Count();

            return PartialView();
        }
    }
}