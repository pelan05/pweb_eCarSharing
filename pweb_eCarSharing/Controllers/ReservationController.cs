using Microsoft.AspNet.Identity;
using pweb_eCarSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace pweb_eCarSharing.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult RentVehicle()
        {
            ViewBag.error = false;
            return View(new NewReservationViewModel());
        }

        // POST: /Reservation/RentVehicle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RentVehicle(NewReservationViewModel model)
        {

            int price = db.Vehicles
                        .Where(a => a.VehicleID == model.VehicleID)
                        .Select(a => a.pricePerMinute)
                        .FirstOrDefault();
            var vehicle = db.Vehicles
                        .Where(a => a.VehicleID == model.VehicleID)
                        .Select(a => a)
                        .FirstOrDefault();
            int? stationStart = db.Vehicles
                        .Where(a => a.VehicleID == model.VehicleID)
                        .Select(a => a.currentStation)
                        .FirstOrDefault();
            var userID = User.Identity.GetUserId();
            int id = db.UsersNib
                        .Where(a => a.userIDstring.Equals(userID))
                        .Select(a => a.userNIBID)
                        .FirstOrDefault();

            if(vehicle != null)
                vehicle.inUse = true;
            else{
                ViewBag.error = true;
                return View();
            }

            _ = db.Reservations.Add( new Reservation
            {
                UserNIBID = id,
                VehicleID = model.VehicleID,
                idStationIdstart = stationStart,
                idStationIdEnd = model.idStationIdEnd,
                predictedUseTime = model.predictedUseTime,
                predictedCost = (price * model.predictedUseTime)
            });
            if (ModelState.IsValid) {
                db.SaveChanges();
                return RedirectToAction("ListRentalData");
            }

            ViewBag.error = true;
            return View();
        }


        public ActionResult RemRentalData()
        {
            ViewBag.error = false;
            return View(new RemReservationViewModel());
        }

        // POST: /Reservation/RemRentalData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemRentalData(RemReservationViewModel model)
        {

            var oldInfo = db.Reservations
                        .Where(a => a.ReservationID == model.reservationID)
                        .Select(a => a)
                        .FirstOrDefault();
            if (oldInfo != null) {
                db.Reservations.Remove(oldInfo);
                db.SaveChanges();
            } else
            {
                ViewBag.error = true;
                return View();
            }


            return RedirectToAction("ListRentalData");
        }

        
        public ActionResult ChangeRentalData()
        {
            ViewBag.error = false;
            return View(new EditReservationViewModel());
        }

        // POST: /Reservation/ChangeRentalData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRentalData(EditReservationViewModel model)
        {
            ViewBag.error = false;
            if (model.ReservationID == 0
                || model.VehicleID == 0
                || model.idStationIdEnd == 0
                || model.predictedUseTime == 0)
            {
                ViewBag.error = true;
                return View();
            }
            else
            {

                var info = db.Reservations
                        .Where(a => a.ReservationID == model.ReservationID)
                        .Select(a => a)
                        .FirstOrDefault();


            int price = db.Vehicles
                        .Where(a => a.VehicleID == model.VehicleID)
                        .Select(a => a.pricePerMinute)
                        .FirstOrDefault();
            int? stationStart = db.Vehicles
                        .Where(a => a.VehicleID == model.VehicleID)
                        .Select(a => a.currentStation)
                        .FirstOrDefault();
            var userID = User.Identity.GetUserId();
            int id = db.UsersNib
                        .Where(a => a.userIDstring.Equals(userID))
                        .Select(a => a.userNIBID)
                        .FirstOrDefault();

            info.VehicleID = model.VehicleID;
            info.idStationIdstart = stationStart;
            info.idStationIdEnd = model.idStationIdEnd;
            info.predictedUseTime = model.predictedUseTime;
            info.predictedCost = (price * model.predictedUseTime);

            
                if (ModelState.IsValid)
                    db.SaveChanges();
                else
                    return View();
            }

            return RedirectToAction("ListRentalData");
        }


        public ActionResult ListRentalData()
        {
            var reservationList = db.Reservations.Select(a => a);
            return View(reservationList.ToList());
        }


        public ActionResult ListUserRentalData()
        {
            var userIDstring = User.Identity.GetUserId();
            int? userID = db.UsersNib.Where(a => a.userIDstring.Equals(userIDstring)).Select(a => a.userNIBID).FirstOrDefault();
            var reservationList = db.Reservations.Where(a => a.UserNIBID == userID).Select(a => a);
            return View(reservationList.ToList());
        }

        public ActionResult UsageStats()
        {   //TODO stats logic

            //Most used vehicle type
            var types = db.Reservations.Select(a => a.Vehicle.vehicleType);
            ViewBag.mostUsedType = "";

            //Most used vehicle stations
            var mostUsedStationName = db.Reservations.Select(a => a.Vehicle.vehicleType).FirstOrDefault();
            var mostUsedStationLocation = db.Reservations.Select(a => a.Vehicle.vehicleType).FirstOrDefault();
            ViewBag.mostUsedStationName = "mockStationName";
            ViewBag.mostUsedStationLocation = "mockStationLocation";

            //usage times in avg
            var avgUsageTime = db.Reservations.Select(a => a.Vehicle.vehicleType).FirstOrDefault();
            ViewBag.avgUsageTime = "mockAvgTime";

            return View();
        }


    }
}