using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LendingLibrary.Models;

namespace LendingLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new LendingModel();
            return View(model);
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