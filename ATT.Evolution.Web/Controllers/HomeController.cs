using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATT.Evolution.Entities;

namespace ATT.Evolution.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Evolution.Entities.Evolution evolution = new Entities.Evolution(10, 1, 9);

            foreach (Being being in evolution.Beings)
            {
                Development development = new Development(being, evolution.NumberOfSteps);
                development.Develop();
            }

            return View(evolution.Beings);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}