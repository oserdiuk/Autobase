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
            catch
            {
                return View();
            }
            return View(viewModel);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Car/Edit/5
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

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
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
