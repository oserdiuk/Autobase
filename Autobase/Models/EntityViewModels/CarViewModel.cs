using AutoMapper;
using BBL.DbManager;
using DAL;
using DAL.Abstract;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobase.Models.EntityViewModels
{
    public class IndexCarViewModel
    {
        public string CarNumber { get; set; }

        public string Model { get; set; }

        public int SeatingAccommodation { get; set; }

        public bool IsIntegral { get; set; }

        public int Capacity { get; set; }

        public string Type { get; set; }

        public static IndexCarViewModel GetViewModel(GlobalRepository repository, int id)
        {
            return Mapper.Map<Car, IndexCarViewModel>(repository.CarRepository.Get(id));
        }

        public static List<IndexCarViewModel> GetViewListOfCars(GlobalRepository repository)
        {
            List<IndexCarViewModel> result = new List<IndexCarViewModel>();
            try
            {
                result = Mapper.Map<IEnumerable<Car>, List<IndexCarViewModel>>(repository.CarRepository.GetAll());

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }

    public class CreateCarViewModel
    {
        public string CarNumber { get; set; }
        public string Model { get; set; }
        public int SeatingAccommodation { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public List<SelectListItem> AllCarTypes { get; set; }

        public CreateCarViewModel()
        {
            RouteDbManager manager = new RouteDbManager();
            this.AllCarTypes = new List<SelectListItem>();
            List<string> types = manager.GetCarTypes();
            foreach (var type in types)
            {
                this.AllCarTypes.Add(new SelectListItem()
                {
                    Text = type,
                    Value = type
                });
            }
        }
    }

    public class EditCarViewModel
    {
    }
}