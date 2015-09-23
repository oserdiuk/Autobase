using Autobase.Models.EntityViewModels;
using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobase.App_Start
{
    public static class InitializeAutoMapper
    {
        public static void Initialize()
        {
            CreateMapperToViewModel();
            CreateMapperToModel();
        }

        private static void CreateMapperToViewModel()
        {
            Mapper.CreateMap<Route, IndexRouteViewModel>()
                .ForMember(route => route.CarNumber, opt => opt.MapFrom(src => src.Car.CarNumber))
                .ForMember(route => route.CarName, opt => opt.MapFrom(src => src.Car.Model))
                .ForMember(route => route.DriverName, opt => opt.MapFrom(src => String.Format("{0} {1}", src.Driver.User.FirstName, src.Driver.User.SecondName)))
                .ForMember(route => route.RouteStatusName, opt => opt.MapFrom(src => src.RouteStatus.StatusName));
            Mapper.CreateMap<Route, CreateRouteViewModel>()
                .ForMember(route => route.ArrivalTime, opt => opt.MapFrom(src => src.ArrivalDate.TimeOfDay))
                .ForMember(route => route.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate.Date))
                .ForMember(route => route.DepartureTime, opt => opt.MapFrom(src => src.DepartureDate.TimeOfDay))
                .ForMember(route => route.DepartureDate, opt => opt.MapFrom(src => src.DepartureDate.Date));

            Mapper.CreateMap<Route, EditRouteViewModel>()
               .ForMember(route => route.ArrivalTime, opt => opt.MapFrom(src => src.ArrivalDate))
               .ForMember(route => route.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
               .ForMember(route => route.DepartureTime, opt => opt.MapFrom(src => src.DepartureDate))
               .ForMember(route => route.DepartureDate, opt => opt.MapFrom(src => src.DepartureDate));

            Mapper.CreateMap<Car, IndexCarViewModel>();
            Mapper.CreateMap<Car, CreateCarViewModel>();
            Mapper.CreateMap<Car, EditCarViewModel>();
            Mapper.CreateMap<Route, ChangeStatusViewModel>()
                .ForMember(r => r.RouteStatusId, a => a.MapFrom(src => src.RouteStatusId))
                .ForMember(r => r.CarId, a => a.MapFrom(src => src.CarId))
                .ForMember(r => r.CarModel, a => a.MapFrom(src => src.Car.Model))
                .ForMember(r => r.CarNumber, a => a.MapFrom(src => src.Car.CarNumber))
                .ForMember(r => r.IsIntegral, a => a.MapFrom(src => src.Car.IsIntegral));

            Mapper.CreateMap<Driver, DriverViewModel>()
                .ForMember(driver => driver.Address, a => a.MapFrom(src => src.User.Address))
                .ForMember(driver => driver.BirthDate, a => a.MapFrom(src => src.User.BirthDate))
                .ForMember(driver => driver.City, a => a.MapFrom(src => src.User.City))
                .ForMember(driver => driver.Email, a => a.MapFrom(src => src.User.Email))
                .ForMember(driver => driver.EmploymentDate, a => a.MapFrom(src => src.User.EmploymentDate))
                .ForMember(driver => driver.FirstName, a => a.MapFrom(src => src.User.FirstName))
                .ForMember(driver => driver.IsDeleted, a => a.MapFrom(src => src.User.IsDeleted))
                .ForMember(driver => driver.SecondName, a => a.MapFrom(src => src.User.SecondName))
                .ForMember(driver => driver.DrivingLicenses, a => a.MapFrom(src => src.DrivingLicenses.Select(l=> l.DrivingLicenseType.Category)))
                .ForMember(driver => driver.Phone, a => a.MapFrom(src => src.User.Phone));
            Mapper.CreateMap<Manager, UserViewModel>()
                .ForMember(manager => manager.Address, a => a.MapFrom(src => src.User.Address))
                .ForMember(manager => manager.BirthDate, a => a.MapFrom(src => src.User.BirthDate))
                .ForMember(manager => manager.City, a => a.MapFrom(src => src.User.City))
                .ForMember(manager => manager.Email, a => a.MapFrom(src => src.User.Email))
                .ForMember(manager => manager.EmploymentDate, a => a.MapFrom(src => src.User.EmploymentDate))
                .ForMember(manager => manager.FirstName, a => a.MapFrom(src => src.User.FirstName))
                .ForMember(manager => manager.IsDeleted, a => a.MapFrom(src => src.User.IsDeleted))
                .ForMember(manager => manager.SecondName, a => a.MapFrom(src => src.User.SecondName))
                .ForMember(manager => manager.Phone, a => a.MapFrom(src => src.User.Phone));

            Mapper.CreateMap<Car, IndexCarViewModel>();
        }

        private static void CreateMapperToModel()
        {
            Mapper.CreateMap<CreateCarViewModel, Car>();
            Mapper.CreateMap<EditCarViewModel, Car>();
            Mapper.CreateMap<CreateRouteViewModel, Route>()
              .ForMember(route => route.ArrivalDate,
                  opt => opt.MapFrom(src => src.ArrivalDate.Date.Add(new TimeSpan(src.ArrivalTime.Hour, src.ArrivalTime.Minute, src.ArrivalTime.Second))))
              .ForMember(route => route.DepartureDate,
                  opt => opt.MapFrom(src => src.DepartureDate.Date.Add(new TimeSpan(src.DepartureTime.Hour, src.DepartureTime.Minute, src.DepartureTime.Second))));
            Mapper.CreateMap<EditRouteViewModel, Route>()
              .ForMember(route => route.ArrivalDate,
                  opt => opt.MapFrom(src => src.ArrivalDate.Date.Add(new TimeSpan(src.ArrivalTime.Hour, src.ArrivalTime.Minute, src.ArrivalTime.Second))))
              .ForMember(route => route.DepartureDate,
                  opt => opt.MapFrom(src => src.DepartureDate.Date.Add(new TimeSpan(src.DepartureTime.Hour, src.DepartureTime.Minute, src.DepartureTime.Second))));

            Mapper.CreateMap<ChangeStatusViewModel, Route>()
                           .ForMember(r => r.RouteStatusId, a => a.MapFrom(src => src.RouteStatusId))
                           .ForMember(r => r.CarId, a => a.MapFrom(src => src.CarId));

            Mapper.CreateMap<ChangeStatusViewModel, Car>()
                           .ForMember(car => car.CarId, a => a.MapFrom(src => src.CarId))
                           .ForMember(car => car.IsIntegral, a => a.MapFrom(src => src.IsIntegral));

            Mapper.CreateMap<Exception, SiteException>()
               .ForMember(ex => ex.InnerException, a => a.MapFrom(src => src.InnerException.Message))
               .ForMember(ex => ex.Message, a => a.MapFrom(src => src.Message))
               .ForMember(ex => ex.Source, a => a.MapFrom(src => src.Source))
               .ForMember(ex => ex.StackTrace, a => a.MapFrom(src => src.StackTrace));            
        }
    }
}