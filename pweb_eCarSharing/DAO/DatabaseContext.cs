using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using pweb_eCarSharing.Models;

namespace e_CarSharing.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {

        }

        public DbSet<CarStation> CarStations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
