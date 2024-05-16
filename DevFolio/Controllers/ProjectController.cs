using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> c481837dab3600e01ee40f7a6a2613662513de6c

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
<<<<<<< HEAD
        public ActionResult CreateProject(TblProject p, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), fileName);
                file.SaveAs(path);

                p.ProjectImageURL = "/img/" + fileName;
                //project.CoverImageUrl = path;
            }
=======
        public ActionResult CreateProject(TblProject p)
        {
>>>>>>> c481837dab3600e01ee40f7a6a2613662513de6c
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
<<<<<<< HEAD
        public ActionResult UpdateProject(TblProject p, HttpPostedFileBase file)
=======
        public ActionResult UpdateProject(TblProject p)
>>>>>>> c481837dab3600e01ee40f7a6a2613662513de6c
        {
            var values = db.TblProject.Find(p.ProjectID);
            values.ProjectTitle = p.ProjectTitle;
            values.ProjectCategoryID = p.TblCategory.CategoryID;
<<<<<<< HEAD
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), fileName);
                file.SaveAs(path);

                values.ProjectImageURL = "/img/" + fileName;
                //project.CoverImageUrl = path;
            }
=======
            values.ProjectImageURL = p.ProjectImageURL;
>>>>>>> c481837dab3600e01ee40f7a6a2613662513de6c
            values.ProjectDate = p.ProjectDate;
            db.SaveChanges();

            return RedirectToAction("ProjectList");
        }
    }
}