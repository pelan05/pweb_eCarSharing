using Microsoft.AspNet.Identity;
using pweb_eCarSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pweb_eCarSharing.Controllers
{
    public class VehicleController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AddVehicle()
        {
            return View(new NewVehicleViewModel());
        }

        // POST: /Vehicle/AddVehicle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVehicle(NewVehicleViewModel model)
        {

            var userID = User.Identity.GetUserId();
            int id = db.UsersNib
                        .Where(a => a.userIDstring.Equals(userID))
                        .Select(a => a.userNIBID)
                        .FirstOrDefault();

            _ = db.Vehicles.Add(new Vehicle
            {
                vehicleOwner = id,
                currentStation = model.currentStationId,
                vehicleType = model.vehicleType, 
                isSmallSized = model.isSmallSized,
                isForTourism = model.isForTourism,
                inUse = false,
                pricePerMinute = model.pricePerMinute,
                remainingBattery = model.remainingBattery
            });
            db.SaveChanges();

            return RedirectToAction("AvailableVehicleList");
        }

            public ActionResult ChangeVehicleData() 
        {
            //TODO
            return View();
        }

        public ActionResult AvailableVehicleList()
        {
            //TODO format table && add names em vez de ids
            var carList = from m in db.Vehicles
                          where m.inUse == false
                          select m;
            return View(carList.ToList());
        }


        public ActionResult InUseVehicleList()
        {
            //TODO format table && add names em vez de ids
            var carList = from m in db.Vehicles
                          where m.inUse == true
                          select m;
            return View(carList.ToList());
        }





    }
}