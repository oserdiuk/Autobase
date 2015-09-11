using BBL.DbManager;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobase.Helpers
{
    public static class ExtensionMethods
    {
        public static void AddCarTypes(this List<SelectListItem> list)
        {
            RouteDbManager manager = new RouteDbManager();
            List<string> types = manager.GetCarTypes();
            foreach (var type in types)
            {
                list.Add(new SelectListItem()
                {
                    Text = type,
                    Value = type
                });
            }
        }

        public static void AddFreeCars(this List<SelectListItem> list, int currentCarId = 0)
        {
            RouteDbManager dbManager = new RouteDbManager();
            List<Car> cars = dbManager.GetCarsFreeForRoute();

            SelectListItem item;
            foreach (var car in cars)
            {
                item = new SelectListItem()
                {
                    Value = car.CarId.ToString(),
                    Text = String.Format("{0} {1} {2}, кол-во мест: {3}, мощность: {4}", car.Type, car.Model, car.CarNumber, car.SeatingAccommodation, car.Capacity)
                };

                if (car.CarId == (currentCarId))
                {
                    item.Selected = true;
                }
                list.Add(item);
            }
        }

        public static void AddRouteStatuses(this List<SelectListItem> list, int currentStatusId = 0)
        {
            RouteDbManager dbManager = new RouteDbManager();
            List<RouteStatus> routeStatuses = dbManager.GetRouteStatuses();

            SelectListItem item;
            foreach (var status in routeStatuses)
            {
                item = new SelectListItem()
                {
                    Value = status.RouteStatusId.ToString(),
                    Text = status.StatusName
                };

                if (status.RouteStatusId == currentStatusId)
                {
                    item.Selected = true;
                }
                list.Add(item);
            }
        }
    }
}