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
            //TODO fill with sample text
            return View();
        }

    }
}