using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
        public ActionResult ProjectList()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            var category = db.TblCategory.Where(m => m.CategoryID == p.TblCategory.CategoryID).FirstOrDefault();
            p.TblCategory = category;
            p.ProjectDate = p.ProjectDate;
            db.TblProject.Add(p);
            db.SaveChanges();

            return RedirectToAction("ProjectList");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.TblProject.Find(id);
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.ProjectID);
            values.ProjectTitle = p.ProjectTitle;
            values.ProjectCategoryID = p.TblCategory.CategoryID;
            values.ProjectImageURL = p.ProjectImageURL;
            values.ProjectDate = p.ProjectDate;
            db.SaveChanges();

            return RedirectToAction("ProjectList");
        }
    }
}