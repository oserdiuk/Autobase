using Autobase.Models.EntityViewModels;
using BBL.DbManager;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobase.Controllers
{
    public class UsersController : Controller
    {
        RouteDbManager dbManager = new RouteDbManager();
        
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetDrivers()
        {
            return PartialView(DriverViewModel.GetViewListOfUsers(dbManager.GetDrivers().ToList<IUser>()));
        }

        [HttpPost]
        public PartialViewResult GetManagers()
        {
            return PartialView(UserViewModel.GetViewListOfUsers(dbManager.GetManagers().ToList<IUser>()));   
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
