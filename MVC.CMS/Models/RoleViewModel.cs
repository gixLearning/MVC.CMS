using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.CMS.Models {
    public class RoleViewModel {
        public IEnumerable<ApplicationUser> UsersWithRole { get; set; }

        
        public IEnumerable<SelectListItem> RolesList { get; set; }
        public string Role { get; set; }
    }
}