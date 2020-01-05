﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Setup() 
        {
            AccountController accountController = new AccountController();
            accountController.registerAtStartup(1, "pedro@gmail.com", "Abc12(3)", "123456789012345678901");
            accountController.registerAtStartup(2, "guilherme@gmail.com", "Abc12(3)", "123456789012345678901");
            accountController.registerAtStartup(3, "gugu666@gmail.com", "Abc12(3)", "123456789012345678901");
            accountController.registerAtStartup(4, "pedrito77@gmail.com", "Abc12(3)", "123456789012345678901");
            accountController.registerAtStartup(5, "ronaldo@gmail.com", "Abc12(3)", "123456789012345678901");
            accountController.registerAtStartup(6, "messi@gmail.com", "Abc12(3)", "123456789012345678901");

            return View("");
        }
    }
}