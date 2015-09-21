using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autobase.Helpers;
using System.ComponentModel;

namespace Autobase.Models.EntityViewModels
{
    public class ChangeStatusViewModel
    {
        [DisplayName("Id рейса")]
        public int RouteId { get; set; }

        [DisplayName("Id машины")]
        public int CarId { get; set; }

        [DisplayName("Номер машины")]
        public string CarNumber { get; set; }

        [DisplayName("Модель машины")]
        public string CarModel { get; set; }

        public int RouteStatusId { get; set; }

        [DisplayName("Машина исправна")]
        public bool IsIntegral { get; set; }

        public List<SelectListItem> RouteStatuses { get; set; }

        public ChangeStatusViewModel()
        {
            this.RouteStatuses = new List<SelectListItem>();
            this.RouteStatuses.AddRouteStatuses(this.RouteStatusId);
        }
        //TODO insert route status, car props: isIntegral
    }
}