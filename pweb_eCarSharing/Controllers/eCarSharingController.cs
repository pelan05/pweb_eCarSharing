using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pweb_eCarSharing.Models;

namespace pweb_eCarSharing.Controllers
{
    public class eCarSharingController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: eCarSharing
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Vehicle()
        {
            return View();
        }
        public ActionResult CarStation()
        {
            return View();
        }
        public ActionResult Reservation()
        {
            return View();
        }
    }
}