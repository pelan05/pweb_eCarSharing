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
            //TODO add view
            //TODO check list data
            return View();
        }


        public ActionResult VehicleList()
        {
            //TODO check list data
            var carList = from m in db.Vehicles
                          select m;
            return View(carList.ToList());
        }





    }
}