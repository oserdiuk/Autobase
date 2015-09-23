using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobase.Models.EntityViewModels
{
    public class DriverViewModel : UserViewModel
    {
        public List<string> DrivingLicenses { get; set; }

        //public static List<DriverViewModel> GetViewListOfDrivers(List<Driver> users)
        //{
        //    List<DriverViewModel> result = new List<DriverViewModel>();
        //    try
        //    {
        //        result = Mapper.Map<IEnumerable<Driver>, List<DriverViewModel>>(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return result;
        //}
    }
}