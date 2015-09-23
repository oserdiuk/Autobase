﻿using Autobase.Helpers;
using Autobase.Models;
using Autobase.Models.EntityViewModels;
using BBL;
using BBL.DbManager;
using DAL.Abstract;
using DAL.Entities;
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
            return PartialView(MapperManager.GetViewListOfEntity<Driver, DriverViewModel>(dbManager.GetDrivers().Where(d => !d.User.IsDeleted).ToList()));
        }

        [HttpPost]
        public PartialViewResult GetManagers()
        {
            return PartialView(MapperManager.GetViewListOfEntity<Manager, UserViewModel>(dbManager.GetManagers().Where(m => !m.User.IsDeleted).ToList()));   
        }

        // GET: Users/Details/5
        public ActionResult DriverDetails(int id)
        {
            return View(MapperManager.Map<Driver, DriverViewModel>(dbManager.GetDriver(id)));
        }

        public ActionResult ManagerDetails(int id)
        {
            return View(MapperManager.Map<Manager, UserViewModel>(dbManager.GetManager(id)));
        }

        public ActionResult Edit(int id, RoleEnum role)
        {
            var m = dbManager.GetUser(id, role);
            var model = RoleMapperManager.Map<RegisterViewModel>(m);
            //if (m.UserInRole is Driver)
            //{
            //    model.AllDrivingLicenses.AddDrivingLicenses();
            //}
            return View(model);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(RegisterViewModel model)
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
