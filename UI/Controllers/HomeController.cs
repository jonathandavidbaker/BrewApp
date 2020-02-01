using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATA;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private brewingEntities db = new brewingEntities();

        public ActionResult Index()
        {
            return View();
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

        public ActionResult ABVCalculator(float og, float fg)
        {
            float abv = (fg - og) * (float)131.25;
            return View(abv);
        }

        [HttpGet]
        public ActionResult RefractCalc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RefractCalc(gravityViewModel gvm)
        {
            return View("gravresults", gvm);
        }
    }
}