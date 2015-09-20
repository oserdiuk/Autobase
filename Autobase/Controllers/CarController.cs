using Autobase.Helpers;
using Autobase.Models.EntityViewModels;
using BBL.DbManager;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobase.Controllers
{
    [RoleAuthorized(Roles = "Admin, Manager")]
    public class CarController : Controller
    {
        DAL.GlobalRepository repository = new DAL.GlobalRepository();
        RouteDbManager dbManager = new RouteDbManager();

        // GET: Car
        public ActionResult Index()
        {
            return View(IndexCarViewModel.GetViewListOfCars(repository));
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View(IndexCarViewModel.GetViewModel(repository, id));
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View(new CreateCarViewModel());
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(CreateCarViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbManager.CreateCar(AutoMapper.Mapper.Map<CreateCarViewModel, Car>(viewModel));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }
            return View(viewModel);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            return View(AutoMapper.Mapper.Map<Car, EditCarViewModel>(dbManager.GetCar(id)));
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditCarViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var carDAL = dbManager.GetCar(id);
                    dbManager.EditCar(AutoMapper.Mapper.Map<EditCarViewModel, Car>(viewModel, carDAL));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }
            return View(viewModel);

        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            if (dbManager.CheckCarForActive(id))
            {
                return View();
            }
            return View(IndexCarViewModel.GetViewModel(repository, id));
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dbManager.DeleteCar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
