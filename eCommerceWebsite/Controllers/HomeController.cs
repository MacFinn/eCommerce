using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //get featured products
            return View();
        }

        public ActionResult Bongs()
        {
            return View();
        }

        public ActionResult Vapourizers()
        {
            return View();
        }

        public ActionResult Papers()
        {
            return View();
        }

        public ActionResult SmokingAccessories()
        {
            return View();
        }

        public ActionResult SmokingParaphenalia()
        {
            return View();
        }

        public ActionResult Brands()
        {
            return View();
        }

        public ActionResult Sale()
        {
            return View();
        }

    }
}