using AutoMapper;
using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(13)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EmploymentDate { get; set; }

        public bool IsDeleted { get; set; }

        public static UserViewModel GetViewModel(IUser user)
        {
            return Mapper.Map<IUser, UserViewModel>(user);
        }

        public static List<UserViewModel> GetViewListOfUsers(List<IUser> users)
        {
            List<UserViewModel> result = new List<UserViewModel>();
            try
            {
                result = Mapper.Map<IEnumerable<IUser>, List<UserViewModel>>(users);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}