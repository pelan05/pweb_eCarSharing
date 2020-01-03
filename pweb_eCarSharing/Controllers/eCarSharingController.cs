using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pweb_eCarSharing.Controllers
{
    public class eCarSharingController : Controller
    {

        // GET: eCarSharing
        public ActionResult Main()
        {
            //TODO fill with sample text
            return View();
        }

        public ActionResult CarStationList()
        {
            //TODO check list data
            return View();
        }

        public ActionResult VehicleList()
        {
            //TODO check list data
            return View();
        }

        public ActionResult RentVehicle()
        {
            // has to be a post?
            //TODO rent form
            return View();
        }

        public ActionResult ListRentalData()
        {
            //TODO check list data
            return View();
        }

        public ActionResult ChangeRentalData()
        {
            //TODO change rent data form
            return View();
        }

        public ActionResult UsageStats()
        {//TODO stats logic


            //Most used vehicle type

            ViewBag.mostUsedType = "mockType";
            //Most used vehicle stations
            
            ViewBag.mostUsedStationName = "mockStationName";
            ViewBag.mostUsedStationLocation = "mockStationLocation";
            //usage times in avg
            
            ViewBag.avgUsageTime = "mockAvgTime";
            
            
            return View();
        }



    }
}