using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.CMS.Models {

    public class City {        
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        public int CountryID { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Countries { get; set; }
    }
}