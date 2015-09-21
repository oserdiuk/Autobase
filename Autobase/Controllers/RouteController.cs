using Autobase.Helpers;
using Autobase.Models.EntityViewModels;
using AutoMapper;
using BBL.DbManager;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Autobase.Controllers
{
    [Authorize]
    public class RouteController : Controller
    {
        DAL.GlobalRepository repository = new DAL.GlobalRepository();
        RouteDbManager dbManager = new RouteDbManager();

        // GET: Route
        public ActionResult Index()
        {
            return View(IndexRouteViewModel.GetViewListOfRoutes(repository));
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View(IndexRouteViewModel.GetViewModel(repository, id));
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View(new CreateRouteViewModel());
        }

        // POST: Route/Create
        [HttpPost]
        public ActionResult Create(CreateRouteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isDriver = Roles.IsUserInRole("Driver");
                    dbManager.CreateRoute(AutoMapper.Mapper.Map<CreateRouteViewModel, Route>(model), isDriver);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }
            return View(model);

        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            if (dbManager.CheckRouteForActive(id))
            {
                return RedirectToAction("Index");
            }

            var route = dbManager.GetRoute(id);
            var view = AutoMapper.Mapper.Map<Route, EditRouteViewModel>(route);
            return View(view);
        }

        // POST: Route/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditRouteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var routeDAL = dbManager.GetRoute(id);
                    dbManager.EditRoute(AutoMapper.Mapper.Map<EditRouteViewModel, Route>(model, routeDAL));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }
            return View(model);

        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            if (dbManager.CheckRouteForActive(id))
            {
                return View();
            }
            return View(IndexRouteViewModel.GetViewModel(repository, id));
        }

        // POST: Route/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dbManager.DeleteRoute(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [RoleAuthorized(Roles = "Admin, Manager")]
        public ActionResult ConfirmRoute(int id)
        {
            dbManager.ConfirmRoute(id);
            return RedirectToAction("Index");
        }

        [RoleAuthorized(Roles = "Driver")]
        public ActionResult ChangeRouteStatus(int id)
        {
            Route route = dbManager.GetRoute(id);
            var viewModel = Mapper.Map<Route, ChangeStatusViewModel>(route);
            return View(viewModel);
        }

        [HttpPost]
        [RoleAuthorized(Roles = "Driver")]
        public ActionResult ChangeRouteStatus(ChangeStatusViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Route route = dbManager.GetRoute(viewModel.RouteId);
                Car car = dbManager.GetCar(viewModel.CarId);
                Mapper.Map<ChangeStatusViewModel, Route>(viewModel, route);
                Mapper.Map<ChangeStatusViewModel, Car>(viewModel, car);
                dbManager.ChangeRouteStatus(route, car);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Sort(IndexRouteViewModel viewModel, int sortId)
        {

        }
    }
}
