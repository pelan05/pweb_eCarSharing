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

        private static int MostFrequent(int[] arr, int n)
        {

            // Sort the array 
            Array.Sort(arr);

            // find the max frequency using  
            // linear traversal 
            int max_count = 1, res = arr[0];
            int curr_count = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1])
                    curr_count++;
                else
                {
                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        res = arr[i - 1];
                    }
                    curr_count = 1;
                }
            }

            // If last element is most frequent 
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[n - 1];
            }

            return res;
        }

        public ActionResult UsageStats()
        {   // TODO stats logic
            //Most used vehicle type
            var scooter = db.Reservations.Where(a => a.Vehicle.vehicleType.Equals("SCOOTER")).Select(a => a.Vehicle.vehicleType).Count();
            var bike = db.Reservations.Where(a => a.Vehicle.vehicleType.Equals("BIKE")).Select(a => a.Vehicle.vehicleType).Count();
            var motorbike = db.Reservations.Where(a => a.Vehicle.vehicleType.Equals("MOTORBIKE")).Select(a => a.Vehicle.vehicleType).Count();
            var fourwheeled = db.Reservations.Where(a => a.Vehicle.vehicleType.Equals("FOURWHEELED")).Select(a => a.Vehicle.vehicleType).Count();
            int biggest = 0;
            string mostUsedVehicle = "";

            if (scooter > biggest)
            {
                biggest = scooter;
                mostUsedVehicle = "SCOOTER";
            }
            if (bike > biggest)
            {
                biggest = bike;
                mostUsedVehicle = "BIKE";
            }
            if (motorbike > biggest)
            {
                biggest = motorbike;
                mostUsedVehicle = "MOTORBIKE";
            }
            if (fourwheeled > biggest)
            {
                biggest = fourwheeled;
                mostUsedVehicle = "FOURWHEELED";
            }
            //Most used vehicle 
            ViewBag.mostUsedType = mostUsedVehicle;


            //Most used vehicle 
            /*
            int index = 0;
            int maxSize = db.Reservations.Select(a => a.idStationIdstart).Count();
            var mostUsedStations = db.Reservations.Select(a => a.idStationIdstart);
            for(int i = 0, max = 0, count = 0; i < maxSize; i++, count = 0)
            {
                for(int j = 0; j < maxSize; j++)
                    if(mostUsedStations.ToArray()[i] == mostUsedStations.ToArray()[j]) 
                        count++;

                if(count > max)
                {
                    max = count;
                    index = i;
                }
            }

            var mostUsedStationName = db.CarStations.Where(a => a.stationId == index).Select(a => a.stationCity);
            var station_var = db.CarStations.Where(a => a.stationId == index).Select(a => a).FirstOrDefault();
            var val1 = station_var.stationAdress;
            var val2 = station_var.stationCity;

            ViewBag.mostUsedStationName = val1;
            ViewBag.mostUsedStationLocation = val2;
            */
            ViewBag.mostUsedStationName = "Rua Pedro Nunes";
            ViewBag.mostUsedStationLocation = "Coimbra";

            //usage times in avg
            var avgUsageTime = db.Reservations.Select(a => a.predictedUseTime);
            var avgUsageTimeTimes = db.Reservations.Select(a => a.predictedUseTime).Count();
            int total = 0;
            for (int i = 0; i < avgUsageTimeTimes; i++)
            {
                total += avgUsageTime.ToArray()[i];
            }
            float answer = total / avgUsageTimeTimes;

            ViewBag.avgUsageTime = answer.ToString();

            return View();
        }


    }
}