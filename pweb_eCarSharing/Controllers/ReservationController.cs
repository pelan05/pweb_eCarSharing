using pweb_eCarSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pweb_eCarSharing.Controllers
{

    public class ReservationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult RentVehicle()
        {

            /*
            public ActionResult AddPhoneNumber()
            {
                return View();
            }

            //
            // POST: /Manage/AddPhoneNumber
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // Generate the token and send it
                var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
                if (UserManager.SmsService != null)
                {
                    var message = new IdentityMessage
                    {
                        Destination = model.Number,
                        Body = "Your security code is: " + code
                    };
                    await UserManager.SmsService.SendAsync(message);
                }
                return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
            }
            */


            // has to be a post?
            //TODO rent form
            return View();
        }

        public ActionResult ListRentalData()
        {
            //TODO check list data
            var reservationList = from m in db.Reservations
                                  select m;
            return View(reservationList.ToList());
        }

        public ActionResult ChangeRentalData()
        {
            //TODO change rent data form
            return View();
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