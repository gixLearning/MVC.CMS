using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC.CMS.Models;

namespace MVC.CMS.DataContexts.Initializers {
    public class ContentDBInitializer : DropCreateDatabaseIfModelChanges<ContentDBContext> {

        protected override void Seed(ContentDBContext context) {
            var countries = new List<Country> {
                new Country {
                    CountryName = "Sweden",
                    Cities = new List<City> {
                    new City { CityName = "Stockholm" },
                    new City { CityName = "Malmö" }
                    }
                },
                new Country {
                    CountryName = "Norway",
                    Cities = new List<City> {
                        new City { CityName = "Oslo" }
                    }
                }
            };

            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
        }
    }
}