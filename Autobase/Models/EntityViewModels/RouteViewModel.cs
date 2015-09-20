using AutoMapper;
using BBL.DbManager;
using DAL;
using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autobase.Helpers;
using Foolproof;
using Autobase.Helpers.ValidationAttributes;

namespace Autobase.Models.EntityViewModels
{
    public class IndexRouteViewModel
    {
        public int RouteId { get; set; }

        public string Direction { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatingDate { get; set; }
        
        public string CarNumber { get; set; }

        public string CarName { get; set; }

        public string RouteStatusName { get; set; }

        public static IndexRouteViewModel GetViewModel(GlobalRepository repository, int id)
        {
            return Mapper.Map<Route, IndexRouteViewModel>(repository.RouteRepository.Get(id));
        }

        public static List<IndexRouteViewModel> GetViewListOfRoutes(GlobalRepository repository)
        {
            List<IndexRouteViewModel> result = new List<IndexRouteViewModel>();
            try
            {
                result = Mapper.Map<IEnumerable<Route>, List<IndexRouteViewModel>>(repository.RouteRepository.GetAll());

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }

    public class CreateRouteViewModel
    {
        public int RouteId { get; set; }

        public string Direction { get; set; }

        [DataType(DataType.Date)]
      //  [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
       // [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [GreaterThanOrEqualTo("DepartureDate", ErrorMessage = "Дата приезда не может быть меньше чем дата выезда.")]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        public string CarId { get; set; }

        public string RouteStatusId { get; set; }

        public string DriverId { get; set; }

       // public List<SelectListItem> RouteStatuses { get; set; }

        public List<SelectListItem> Drivers { get; set; }

        public List<SelectListItem> Cars { get; set; }

        public CreateRouteViewModel()
        {
           // this.RouteStatuses = new List<SelectListItem>();
            this.Drivers = new List<SelectListItem>();
            this.Cars = new List<SelectListItem>();
           // this.RouteStatuses.AddRouteStatuses();
            this.Cars.AddFreeCars();
            this.Drivers.AddDrivers();
        }
    }

    public class EditRouteViewModel
    {
        public int RouteId { get; set; }

        public string Direction { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy}", ApplyFormatInEditMode = true)]
     //   [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        public DateTime CreatingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
     //   [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        public string CarId { get; set; }

        public string RouteStatusId { get; set; }

        public string DriverId { get; set; }

        //public List<SelectListItem> RouteStatuses { get; set; }

        public List<SelectListItem> Drivers { get; set; }

        public List<SelectListItem> Cars { get; set; }

        public EditRouteViewModel()
        {
            //this.RouteStatuses = new List<SelectListItem>();
            this.Cars = new List<SelectListItem>();
            //this.RouteStatuses.AddRouteStatuses(Convert.ToInt32(this.RouteStatusId));
            this.Cars.AddFreeCars(Convert.ToInt32(this.CarId));
            this.Drivers = new List<SelectListItem>();
            this.Drivers.AddDrivers();
        }
    }
}