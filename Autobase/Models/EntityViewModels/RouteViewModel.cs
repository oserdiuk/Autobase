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

namespace Autobase.Models.EntityViewModels
{
    public class IndexRouteViewModel
    {
        public int RouteId { get; set; }

        public string Direction { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }

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
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        public string CarId { get; set; }

        public string RouteStatusId { get; set; }

        public List<SelectListItem> RouteStatuses { get; set; }

        public List<SelectListItem> Cars { get; set; }

        public CreateRouteViewModel()
        {
            this.RouteStatuses = new List<SelectListItem>();
            this.Cars = new List<SelectListItem>();
            RouteDbManager dbManager = new RouteDbManager();
            List<Car> cars = dbManager.GetCarsFreeForRoute();
            List<RouteStatus> routeStatuses = dbManager.GetRouteStatuses();

            foreach (var car in cars)
            {
                this.Cars.Add(new SelectListItem()
                {
                    Value = car.CarId.ToString(),
                    Text = String.Format("{0} {1} {2}, кол-во мест: {3}, мощность: {4}", car.Type, car.Model, car.CarNumber, car.SeatingAccommodation, car.Capacity)
                });
            }

            foreach (var status in routeStatuses)
            {
                this.RouteStatuses.Add(new SelectListItem()
                {
                    Value = status.RouteStatusId.ToString(),
                    Text = status.StatusName
                });
            }
        }

    }

    public class EditRouteViewModel
    {

    }
}