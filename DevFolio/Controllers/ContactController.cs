using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
       
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        public ActionResult MessageList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }
        public ActionResult ReadMessage(int id)
        {
            var values = db.TblContact.Find(id);
            values.ContactIsRead = true;
            db.SaveChanges();
            return View(values);
        }

        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            var value = db.TblContact.Add(p);
            db.SaveChanges();
            ViewBag.m = "Mesajınız Alınmıştır.";
            return RedirectToAction("MessageList");
        }
    }
}