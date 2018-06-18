using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.CMS.Models
{

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public IList<System.Web.Mvc.SelectListItem> CountryList { get; set; }
        public int CountryId { get; set; }

        public IList<System.Web.Mvc.SelectListItem> CityList { get; set; }
        public int CityId { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
    }
}
