using AutoMapper;
using BBL;
using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autobase.Models.EntityViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Город")]
        public string City { get; set; }

        [Required]
        [StringLength(13)]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата трудоустройства")]
        public DateTime EmploymentDate { get; set; }

        [DisplayName("Удален")]
        public bool IsDeleted { get; set; }
    }
}