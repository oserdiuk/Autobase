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

        public static void AddDrivers(this List<SelectListItem> list)
        {
            RouteDbManager manager = new RouteDbManager();
            List<Driver> drivers = manager.GetDrivers();
            string driverLicenses = String.Empty;
            foreach (var driver in drivers)
            {
                foreach (var license in driver.DrivingLicenses)
                {
                    driverLicenses += license.DrivingLicenseType.Category + ", ";
                }

                list.Add(new SelectListItem()
                {
                    Text = String.Format("{0} {1} ({2})", driver.User.FirstName, driver.User.SecondName, driverLicenses.Substring(0, driverLicenses.Length - 3)),
                    Value = driver.DriverId.ToString()
                });
            }
        }

        public static void AddFreeCars(this List<SelectListItem> list, int currentCarId = 0)
        {
            RouteDbManager dbManager = new RouteDbManager();
            List<Car> cars = dbManager.GetCarsFreeForRoute();
            cars.Add(dbManager.GetCar(currentCarId));

            SelectListItem item;
            foreach (var car in cars)
            {
                if (car != null)
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

        public static void AddDrivingLicenses(this List<SelectListItem> list, Driver driver = null)
        {
            RouteDbManager dbManager = new RouteDbManager();
            List<DrivingLicenseType> licenses = dbManager.GetDrivingLicenseTypes();

            SelectListItem item;
            foreach (var license in licenses)
            {
                item = new SelectListItem()
                {
                    Text = String.Format("{0} ({1})", license.Category, license.TransportType),
                    Value = license.DrivingLicenseTypeId.ToString()
                };

                if (driver != null)
                {
                    item.Selected = driver.DrivingLicenses.Where(l => l.DrivingLicenseTypeId == license.DrivingLicenseTypeId).Count() > 0;
                }
                list.Add(item);
            }
        }

        public static bool GreaterThanNow(this DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}