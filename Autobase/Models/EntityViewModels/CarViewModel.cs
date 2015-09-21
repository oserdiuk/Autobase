using AutoMapper;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Autobase.Helpers;
using System.ComponentModel;

namespace Autobase.Models.EntityViewModels
{
    public class IndexCarViewModel
    {
        [DisplayName("Id машины")]
        public string CarId { get; set; }

        [DisplayName("Номер машины")]
        public string CarNumber { get; set; }

        [DisplayName("Модель машины")]
        public string Model { get; set; }

        [DisplayName("Количество мест")]
        public int SeatingAccommodation { get; set; }

        [DisplayName("Занята")]
        public bool IsBusy { get; set; }

        [DisplayName("Машина исправна")]
        public bool IsIntegral { get; set; }

        [DisplayName("Мощность")]
        public int Capacity { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }

        public static IndexCarViewModel GetViewModel(GlobalRepository repository, int id)
        {
            return Mapper.Map<Car, IndexCarViewModel>(repository.CarRepository.Get(id));
        }

        public static List<IndexCarViewModel> GetViewListOfCars(GlobalRepository repository)
        {
            List<IndexCarViewModel> result = new List<IndexCarViewModel>();
            try
            {
                result = Mapper.Map<IEnumerable<Car>, List<IndexCarViewModel>>(repository.CarRepository.GetAll());

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }

    public class CreateCarViewModel
    {
        [DisplayName("Номер машины")]
        public string CarNumber { get; set; }

        [DisplayName("Модель машины")]
        public string Model { get; set; }

        [DisplayName("Количество мест")]
        public int SeatingAccommodation { get; set; }

        [DisplayName("Мощность")]
        public int Capacity { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }

        public List<SelectListItem> AllCarTypes { get; set; }

        public CreateCarViewModel()
        {
            this.AllCarTypes = new List<SelectListItem>();
            this.AllCarTypes.AddCarTypes();
        }

    }

    public class EditCarViewModel
    {
        [DisplayName("Id машины")]
        public string CarId { get; set; }

        [DisplayName("Номер машины")]
        public string CarNumber { get; set; }

        [DisplayName("Модель машины")]
        public string Model { get; set; }

        [DisplayName("Количество мест")]
        public int SeatingAccommodation { get; set; }

        [DisplayName("Мощность")]
        public int Capacity { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }

        [DisplayName("Машина исправна")]
        public bool IsIntegral { get; set; }

        public List<SelectListItem> AllCarTypes { get; set; }

        public EditCarViewModel()
        {
            this.AllCarTypes = new List<SelectListItem>();
            this.AllCarTypes.AddCarTypes();
        }
    }

}