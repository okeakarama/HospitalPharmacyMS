using HPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPMS.Controllers
{
    public class PharmacyController : Controller
    {
        private MainDBContext db = new MainDBContext();

        public ActionResult Index()
        {
            return View();
        }



    }
}
