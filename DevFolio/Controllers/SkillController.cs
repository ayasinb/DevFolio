using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SkillController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
        
        public ActionResult SkillList()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillAdd(TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult SkillDelete(int id)
        {
            var value=db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpGet]
        public ActionResult SkillUpdate(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);
        }
       [HttpPost]
       public ActionResult SkillUpdate(TblSkill p)
        {
            var value = db.TblSkill.Find(p.SkillID);
            value.SkillTitle = p.SkillTitle;
            value.SkillValue = p.SkillValue;
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }

    }
}