using AutoMapper;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Autobase.Helpers;

namespace Autobase.Models.EntityViewModels
{
    public class IndexCarViewModel
    {
        public string CarId { get; set; }

        public string CarNumber { get; set; }

        public string Model { get; set; }

        public int SeatingAccommodation { get; set; }

        public bool IsBusy { get; set; }

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
            this.AllCarTypes = new List<SelectListItem>();
            this.AllCarTypes.AddCarTypes();
        }

    }

    public class EditCarViewModel
    {
        public string CarId { get; set; }
        public string CarNumber { get; set; }
        public string Model { get; set; }
        public int SeatingAccommodation { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public List<SelectListItem> AllCarTypes { get; set; }

        public EditCarViewModel()
        {
            this.AllCarTypes = new List<SelectListItem>();
            this.AllCarTypes.AddCarTypes();
        }
    }

}