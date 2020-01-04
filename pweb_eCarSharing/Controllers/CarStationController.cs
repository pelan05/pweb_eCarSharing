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
                                 orderby m.stationCity
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
            db.SaveChanges();

            return RedirectToAction("CarStationList");
        }




    }
}