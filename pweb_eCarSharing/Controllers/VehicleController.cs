﻿using Microsoft.AspNet.Identity;
using pweb_eCarSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pweb_eCarSharing.Controllers
{
    [Authorize]
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
            if (ModelState.IsValid)
                db.SaveChanges();
            else
                return View();

            return RedirectToAction("AvailableVehicleList");
        }

        public ActionResult ChangeVehicleData()
        {
            ViewBag.error = false;
            return View(new changeVehiclePriceViewModel());
        }

        // POST: /Vehicle/ChangeVehicleData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeVehicleData(changeVehiclePriceViewModel model)
        {
            var info = db.Vehicles
                        .Where(a => a.VehicleID == model.vehicleID)
                        .Select(a => a)
                        .FirstOrDefault();

            if(info != null)
                info.pricePerMinute = model.pricePerMinute;

            if (ModelState.IsValid && info != null)
                db.SaveChanges();
            else {
                ViewBag.error = true;
                return View();
            }

            return RedirectToAction("AvailableVehicleList");
        }

        public ActionResult AvailableVehicleList()
        {
            var carList = from m in db.Vehicles
                          where m.inUse == false
                          select m;
            return View(carList.ToList());
        }


        public ActionResult InUseVehicleList()
        {
            var carList = from m in db.Vehicles
                          where m.inUse == true
                          select m;
            return View(carList.ToList());
        }


        public ActionResult RemVehicle()
        {
            ViewBag.error = false;
            return View(new RemVehicleViewModel());
        }

        // POST: /Vehicle/RemVehicle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemVehicle(RemVehicleViewModel model)
        {
            var oldInfo = db.Vehicles
                        .Where(a => a.VehicleID == model.vehicleID)
                        .Select(a => a)
                        .FirstOrDefault();
            if (!(oldInfo == null)){
                db.Vehicles.Remove(oldInfo);
                db.SaveChanges();

                return RedirectToAction("AvailableVehicleList");
            }

            ViewBag.error = true;
            return View();
        }


    }
}