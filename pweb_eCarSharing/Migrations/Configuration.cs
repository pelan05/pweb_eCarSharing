namespace pweb_eCarSharing.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using pweb_eCarSharing.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<pweb_eCarSharing.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(pweb_eCarSharing.Models.ApplicationDbContext context)
        {
            // Add admin role
            if (!(context.Roles.Where(r => r.Name == "Admin").First().Name == "Admin"))
            {
                context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Admin"));
                context.SaveChanges();
            }

            // Add user role
            if (!(context.Roles.Where(r => r.Name == "User").First().Name == "User"))
            {
                context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("User"));
                context.SaveChanges();
            }

            // Mock data
            // Car Stations
            if (context.CarStations.Count() == 0)
            {
                var stations = new List<CarStation>
                {
                new CarStation { stationAdress = "Rua Belele 1", stationCity = "Coimbra"},
                new CarStation { stationAdress = "Rua Belele 2", stationCity = "Coimbra"},
                new CarStation { stationAdress = "Rua Belele 3", stationCity = "Coimbra"},
                new CarStation { stationAdress = "Rua Belele 4", stationCity = "Coimbra"},
                new CarStation { stationAdress = "Rua Belele 5", stationCity = "Coimbra"}
                };
                context.CarStations.AddRange(stations);
                context.SaveChanges();
            }

            // Users
            if (context.AppUsers.Count() == 0)
            {
                var users = new List<User>
                {
                    new User { name = "pedro", isAdmin = false, email = "pelan@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1994,1,25) },
                    new User { name = "guilherme", isAdmin = false, email = "gigi@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1994,1,25) },
                    new User { name = "paulo", isAdmin = false, email = "paul5@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1994,1,25) },
                    new User { name = "tania", isAdmin = false, email = "tanita@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1994,1,25) },
                    new User { name = "diana", isAdmin = false, email = "didi09@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1994,1,25) }
                };
                context.AppUsers.AddRange(users);
                context.SaveChanges();

            }

            // FIXME ADD COMPLETE INFORMATION
            // Vehicles
            if (context.Vehicles.Count() == 0)
            {
                var vehicles = new List<Vehicle>
                {
                                new Vehicle { vehicleOwner = 2, currentStation = 12, vehicleType = Vehicle.VehicleType.BIKE.ToString(), inUse = false, pricePerMinute = 20 },
                                new Vehicle { vehicleOwner = 2, currentStation = 12, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 50 },
                                new Vehicle { vehicleOwner = 2, currentStation = 12, vehicleType = Vehicle.VehicleType.MOTORBIKE.ToString(), inUse = false, pricePerMinute = 10 },
                                new Vehicle { vehicleOwner = 2, currentStation = 12, vehicleType = Vehicle.VehicleType.SCOOTER.ToString(), inUse = true, pricePerMinute = 30 },
                                new Vehicle { vehicleOwner = 2, currentStation = 12, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = false, pricePerMinute = 20 }
                };
                context.Vehicles.AddRange(vehicles);
                context.SaveChanges();
            }
        }
    }
}
