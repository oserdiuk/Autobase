using Autobase.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobase.Controllers
{
    public class HomeController : Controller
    {
        //private IMotorDepotRepository repository;

        //public HomeController(IMotorDepotRepository repository)
        //{
        //    this.repository = repository;
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}