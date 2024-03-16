using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AdressController : Controller
    {
        DbDevfolioEntities db = new DbDevfolioEntities();
        public ActionResult AddressList()
        {
            var value = db.TblAdress.ToList();
            ViewBag.addressCount = db.TblAdress.Count();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {
            var countAddress = db.TblAdress.Count();
            if (countAddress > 0)
            {
                ViewBag.countAddress = countAddress;

            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(TblAdress p)
        {
            var countAddress = db.TblAdress.Count();
            if (countAddress > 0)
            {
                return RedirectToAction("AddressList");
            }
            else
            {
                db.TblAdress.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("AddressList");

        }

        public ActionResult DeleteAddress(int id)
        {
            var values = db.TblAdress.Find(id);
            db.TblAdress.Remove(values);
            db.SaveChanges();

            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = db.TblAdress.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(TblAdress p)
        {
            var values = db.TblAdress.Find(p.AdressID);
            values.AdressDescription = p.AdressDescription;
            values.AdressLocation = p.AdressLocation;
            values.AdressEmail = p.AdressEmail;
            values.AdressPhoneNumber = p.AdressPhoneNumber;
            db.SaveChanges();

            return RedirectToAction("AddressList");
        }
    }
}