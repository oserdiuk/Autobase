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
using System.ComponentModel;

namespace Autobase.Models.EntityViewModels
{
    public class IndexRouteViewModel
    {
        [DisplayName("Id рейса")]
        public int RouteId { get; set; }

        [DisplayName("Направление")]
        public string Direction { get; set; }

        [DisplayName("Дата отправления")]
        [DataType(DataType.DateTime)]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Дата прибытия")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime CreatingDate { get; set; }

        [DisplayName("Номер машины")]
        public string CarNumber { get; set; }

        [DisplayName("Модель машины")]
        public string CarName { get; set; }

        [DisplayName("Статус рейса")]
        public string RouteStatusName { get; set; }

        [DisplayName("Водитель")]
        public string DriverName { get; set; }

        public static IndexRouteViewModel GetViewModel(Route route)
        {
            return Mapper.Map<Route, IndexRouteViewModel>(route);
        }

        public static List<IndexRouteViewModel> GetViewListOfRoutes(List<Route> routes)
        {
            List<IndexRouteViewModel> result = new List<IndexRouteViewModel>();
            try
            {
                result = Mapper.Map<IEnumerable<Route>, List<IndexRouteViewModel>>(routes);

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
        [DisplayName("Id рейса")]
        public int RouteId { get; set; }

        [DisplayName("Направление")]
        public string Direction { get; set; }

        [DisplayName("Дата отправления")]
        [DataType(DataType.Date)]
        //  [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Дата прибытия")]
        [DataType(DataType.Date)]
        // [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [GreaterThanOrEqualTo("DepartureDate", ErrorMessage = "Дата приезда не может быть меньше чем дата выезда.")]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("Время отправления")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DisplayName("Время прибытия")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        [DisplayName("Id машины")]
        public string CarId { get; set; }

        [DisplayName("Статус рейса")]
        public string RouteStatusId { get; set; }

        [DisplayName("Водитель")]
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
        [DisplayName("Id рейса")]
        public int RouteId { get; set; }

        [DisplayName("Направление")]
        public string Direction { get; set; }

        [DisplayName("Дата создания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy}", ApplyFormatInEditMode = true)]
        //   [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        public DateTime CreatingDate { get; set; }

        [DisplayName("Дата отправления")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //   [RangeDate(ErrorMessage = "Дата должна быть больше чем сегодняшнее число.")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Дата прибытия")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("Время отправления")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DisplayName("Время прибытия")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        [DisplayName("Id машины")]
        public string CarId { get; set; }

        [DisplayName("Водитель")]
        public string DriverId { get; set; }

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