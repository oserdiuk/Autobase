using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Autobase.Models.EntityViewModels
{
    public class DriverViewModel : UserViewModel
    {
        [DisplayName("Водительские права")]
        public List<string> DrivingLicenses { get; set; }
    }
}