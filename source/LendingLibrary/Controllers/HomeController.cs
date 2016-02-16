using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LendingLibrary.Domain;
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

        [HttpPost]
        public ActionResult Index(LendingModel lendingModel)
        {
            ViewBag.Message = "Successfully Lended";
            return View(lendingModel);
        }
    }
}