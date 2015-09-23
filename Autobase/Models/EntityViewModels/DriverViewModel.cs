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
    }
}