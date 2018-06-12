using MVC.CMS.Models;
using System.Data.Entity;

namespace MVC.CMS.DataContexts {

    public class ContentDBContext : DbContext {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public ContentDBContext() : base("name=ContentDBConnection") {
            
            this.Database.Log = (s) => System.Diagnostics.Debug.WriteLine(s);
        }
    }
}