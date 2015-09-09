using AutoMapper;
using DAL;
using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        //public IndexRouteViewModel()
        //{
            
        //        //.ForMember("RouteId", opt => opt.MapFrom(c => c.RouteId))
        //        //.ForMember("Direction", opt => opt.MapFrom(c => c.Direction))
        //        //.ForMember("DepartureDate", opt => opt.MapFrom(c => c.DepartureDate))
        //        //.ForMember("ArrivalDate", opt => opt.MapFrom(c => c.ArrivalDate))
        //        //.ForMember("Car", opt => opt.MapFrom(c => c.Car))
        //        //.ForMember("RouteStatus", opt => opt.MapFrom(c => c.RouteStatus));
        //}

        public static IndexRouteViewModel GetViewModel(IRepository<Route> routeRepository, int id)
        {
            return Mapper.Map<Route, IndexRouteViewModel>(routeRepository.Get(id));
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

        //public static Route GetEntity(IndexRouteViewModel viewModel)
        //{
        //    return Mapper.Map<IndexRouteViewModel, Route>(viewModel);
        //}
        
    }

    public class CreateRouteViewModel
    {

    }

    public class EditRouteViewModel
    {

    }
}