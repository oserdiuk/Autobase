﻿using AutoMapper;
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
            this.RouteStatuses.AddRouteStatuses();
            this.Cars.AddFreeCars();
        }

    }

    public class EditRouteViewModel
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

        public EditRouteViewModel()
        {
            this.RouteStatuses = new List<SelectListItem>();
            this.Cars = new List<SelectListItem>();
            this.RouteStatuses.AddRouteStatuses(Convert.ToInt32(this.RouteStatusId));
            this.Cars.AddFreeCars(Convert.ToInt32(this.CarId));
        }
    }
}