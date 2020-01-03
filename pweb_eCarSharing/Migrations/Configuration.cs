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
            try
            {
                // Add admin role
                if (!(context.Roles.Where(r => r.Name == "Admin").FirstOrDefault()?.Name == "Admin"))
                {
                    context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Admin"));
                    context.SaveChanges();
                }

                // Add user role
                if (!(context.Roles.Where(r => r.Name == "User").FirstOrDefault()?.Name == "User"))
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
                new CarStation { stationAdress = "Rua Belele 5", stationCity = "Coimbra"},
                new CarStation { stationCity = "Porto", stationAdress = "Rua das Baterias, 158" },
                new CarStation { stationCity = "Lisboa", stationAdress = "Rua das Tomadas, 123" },
                new CarStation { stationCity = "Algarve", stationAdress = "Rua das Portas, 999" },
                new CarStation { stationCity = "Porto", stationAdress = "Rua das Casas, 666" },
                new CarStation { stationCity = "Coimbra", stationAdress = "Rua do Brasil, 133" }
                };
                    context.CarStations.AddRange(stations);
                    context.SaveChanges();
                }

                // Users
                if (context.AppUsers.Count() == 0)
                {
                    var users = new List<User>
                {
                    new User { name = "pedro", isAdmin = false, email = "pelan05@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1997,9,3) },
                    new User { name = "guilherme", isAdmin = false, email = "gigi60@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1995,8,20) },
                    new User { name = "paulo", isAdmin = false, email = "paulo5@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1996,3,6) },
                    new User { name = "tania", isAdmin = false, email = "tanita77@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1995,1,11) },
                    new User { name = "diana", isAdmin = false, email = "didi09@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime(1998,10,30) }
                };
                    context.AppUsers.AddRange(users);
                    context.SaveChanges();

                }


                // Vehicles
                if (context.Vehicles.Count() == 0)
                {
                    var vehicles = new List<Vehicle>{
                        new Vehicle { vehicleOwner = 2, currentStation = 2, vehicleType = Vehicle.VehicleType.BIKE.ToString(), inUse = false, pricePerMinute = 20 },
                        new Vehicle { vehicleOwner = 4, currentStation = 3, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 50 },
                        new Vehicle { vehicleOwner = 4, currentStation = 4, vehicleType = Vehicle.VehicleType.MOTORBIKE.ToString(), inUse = false, pricePerMinute = 10 },
                        new Vehicle { vehicleOwner = 3, currentStation = 5, vehicleType = Vehicle.VehicleType.SCOOTER.ToString(), inUse = true, pricePerMinute = 30 },
                        new Vehicle { vehicleOwner = 3, currentStation = 6, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = false, pricePerMinute = 20 }
                    };
                    context.Vehicles.AddRange(vehicles);
                    context.SaveChanges();
                }

                // Reservations
                if (context.Reservations.Count() == 0)
                {
                    var reservations = new List<Reservation>{
                        new Reservation { UserID = 2, VehicleID = 3, idStationIdstart = 1, idStationIdEnd = 2, predictedUseTime = 5, predictedCost = 5},
                        new Reservation { UserID = 3, VehicleID = 5, idStationIdstart = 1, idStationIdEnd = 3, predictedUseTime = 20, predictedCost = 20},
                    };
                    context.Reservations.AddRange(reservations);
                    context.SaveChanges();
                }




                context.SaveChanges();
            }
            catch (DbEntityValidationException e) // for debugging purposes
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
    }
}
