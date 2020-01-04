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
            //TODO check list data
            // var userId = User.Identity.GetUserId();
            var carStationList = from m in db.CarStations
                                 orderby m.stationCity
                                 select m;
            return View(carStationList.ToList());
        }

        public ActionResult AddCarStation()
        {
            //TODO add view
            //TODO check list data
            return View();
        }




    }
}