using Microsoft.AspNet.Identity;
using pweb_eCarSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pweb_eCarSharing.Controllers
{

    public class CarStationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult CarStationList()
        {
            var carStationList = from m in db.CarStations
                                 orderby m.stationId
                                 select m;
            return View(carStationList.ToList());
        }

        public ActionResult AddCarStation()
        {
            return View(new AddCarStationViewModel());
        }
        // POST: /CarStation/AddCarStation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarStation(AddCarStationViewModel model)
        {
            _ = db.CarStations.Add(new CarStation
            {
                stationCity = model.stationCity,
                stationAdress = model.stationAdress
            });
            if (ModelState.IsValid)
                db.SaveChanges();
            else
                return View();

            return RedirectToAction("CarStationList");
        }

        public ActionResult RemCarStation()
        {
            ViewBag.error = false;
            return View(new RemCarStationViewModel());
        }

        // POST: /CarStation/RemCarStation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemCarStation(RemCarStationViewModel model)
        {
            var oldInfo = db.CarStations
                       .Where(a => a.stationId == model.stationID)
                       .Select(a => a)
                       .FirstOrDefault();

            if (!(oldInfo == null))
            {
                ViewBag.error = false;
                db.CarStations.Remove(oldInfo);

                db.SaveChanges();
                return RedirectToAction("CarStationList");
            }

            ViewBag.error = true;
            return View();
        }
    }
}