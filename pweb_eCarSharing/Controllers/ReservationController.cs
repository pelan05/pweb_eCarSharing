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

    public class ReservationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult RentVehicle()
        {
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
            int? stationStart = db.Vehicles
                        .Where(a => a.VehicleID == model.VehicleID)
                        .Select(a => a.currentStation)
                        .FirstOrDefault();
            var userID = User.Identity.GetUserId();
            int id = db.UsersNib
                        .Where(a => a.userIDstring.Equals(userID))
                        .Select(a => a.userNIBID)
                        .FirstOrDefault();
            

            _ = db.Reservations.Add( new Reservation
            {
                UserNIBID = id,
                VehicleID = model.VehicleID,
                idStationIdstart = stationStart,
                idStationIdEnd = model.idStationIdEnd,
                predictedUseTime = model.predictedUseTime,
                predictedCost = (price * model.predictedUseTime)
            });
            db.SaveChanges();

            return RedirectToAction("ListRentalData");
        }


        public ActionResult RemRentalData()
        {
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
            if (!(oldInfo == null)) { 
             
            db.Reservations.Remove(oldInfo);

            db.SaveChanges();

            }
            return RedirectToAction("ListRentalData");
        }

        
        public ActionResult ChangeRentalData()
        {
            return View(new EditReservationViewModel());
        }

        // POST: /Reservation/ChangeRentalData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRentalData(EditReservationViewModel model)
        {

            var oldInfo = db.Reservations
                        .Where(a => a.ReservationID == model.ReservationID)
                        .Select(a => a)
                        .FirstOrDefault();

            db.Reservations.Remove(oldInfo);


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

            _ = db.Reservations.Add(new Reservation
            {
                UserNIBID = id,
                VehicleID = model.VehicleID,
                idStationIdstart = stationStart,
                idStationIdEnd = model.idStationIdEnd,
                predictedUseTime = model.predictedUseTime,
                predictedCost = (price * model.predictedUseTime)
            });
            db.SaveChanges();

            return RedirectToAction("ListRentalData");
        }





        public ActionResult ListRentalData()
        {
            //TODO check list data
            var reservationList = from m in db.Reservations
                                  select m;
            return View(reservationList.ToList());
        }


        public ActionResult UsageStats()
        {   //TODO stats logic

            //Most used vehicle type
            var mostUsedType = from m in db.Reservations
                               select m.Vehicle;
            ViewBag.mostUsedType = "mockType";

            //Most used vehicle stations
            var mostUsedStationName = from m in db.Reservations
                                      select m.Vehicle;
            var mostUsedStationLocation = from m in db.Reservations
                                          select m.Vehicle;
            ViewBag.mostUsedStationName = "mockStationName";
            ViewBag.mostUsedStationLocation = "mockStationLocation";

            //usage times in avg
            var avgUsageTime = from m in db.Reservations
                               select m.Vehicle;
            ViewBag.avgUsageTime = "mockAvgTime";

            return View();
        }


    }
}