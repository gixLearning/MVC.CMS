using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.CMS.Models {
    public class CountryCityViewModel {
        public int CountryID { get; set; }
        public IList<SelectListItem> Country { get; set; }

    }
}