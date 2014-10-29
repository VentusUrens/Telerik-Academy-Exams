namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Cars.Data.Migrations;
    using Cars.Models;

    public class CarsDBContext : DbContext
    {
        // Your context has been configured to use a 'CarsDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Cars.Data.CarsDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CarsDBContext' 
        // connection string in the application configuration file.
        public CarsDBContext()
            : base("CarsDBContext")
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDBContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}