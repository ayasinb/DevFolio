using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();

        public ActionResult SocialMediaList()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SocialMediaAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SocialMediaAdd(TblSocialMedia p)
        {
            db.TblSocialMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult SocialMediaDelete(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public ActionResult SocialMediaUpdate(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult SocialMediaUpdate(TblSocialMedia p)
        {
            var value = db.TblSocialMedia.Find(p.SocialMediaID);
            value.SocialMediaPlatformName = p.SocialMediaPlatformName;
            value.SocialMediaIconURL = p.SocialMediaIconURL;
            value.SocialMediaRedirectURL = p.SocialMediaRedirectURL;
            value.SocialMediaStatus = p.SocialMediaStatus;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}