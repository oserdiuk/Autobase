using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autobase.Helpers;

namespace Autobase.Models.EntityViewModels
{
    public class ChangeStatusViewModel
    {
        public int CarId { get; set; }
        public string CarNumber { get; set; }
        public string CarModel { get; set; }
        public int RouteStatusId { get; set; }
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