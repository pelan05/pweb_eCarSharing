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