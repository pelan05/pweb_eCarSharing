namespace pweb_eCarSharing.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using pweb_eCarSharing.Models;
    using pweb_eCarSharing.Controllers;

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

                // UsersNIb
                if (context.UsersNib.Count() == 0)
                {
                    var users = new List<UserNIB>
                {
                    new UserNIB { userNIBID = 1, userIDstring = "", NIB = "123456789012345678901", Role = "Admin"},
                    new UserNIB { userNIBID = 2, userIDstring = "", NIB = "123456789012345678901", Role = "Admin"},
                    new UserNIB { userNIBID = 3, userIDstring = "", NIB = "123456789012345678901", Role = "Regular"},
                    new UserNIB { userNIBID = 4, userIDstring = "", NIB = "123456789012345678901", Role = "Regular"},
                    new UserNIB { userNIBID = 5, userIDstring = "", NIB = "123456789012345678901", Role = "Regular"},
                    new UserNIB { userNIBID = 6, userIDstring = "", NIB = "123456789012345678901", Role = "Regular"}
                };
                    context.UsersNib.AddRange(users);
                    context.SaveChanges();
                }


                // Add admin role
                if (!(context.Roles.Where(r => r.Name == "Admin").FirstOrDefault()?.Name == "Admin"))
                {
                    context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Admin"));
                    context.SaveChanges();
                }

                // Add user role
                if (!(context.Roles.Where(r => r.Name == "User").FirstOrDefault()?.Name == "Regular"))
                {
                    context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Regular"));
                    context.SaveChanges();
                }

                // Mock data
                // Car Stations
                if (context.CarStations.Count() == 0)
                {
                    var stations = new List<CarStation>
                    {
                    new CarStation { stationAdress = "Rua das Baterias, 158", stationCity = "Porto" },
                    new CarStation { stationAdress = "Rua das Tomadas, 123", stationCity = "Lisboa" },
                    new CarStation { stationAdress = "Rua das Portas, 999", stationCity = "Algarve" },
                    new CarStation { stationAdress = "Rua das Casas, 666", stationCity = "Porto" },
                    new CarStation { stationAdress = "Rua do Brasil, 133", stationCity = "Coimbra" },
                    new CarStation { stationAdress = "Rua Belele 1", stationCity = "Coimbra" },
                    new CarStation { stationAdress = "Rua Belele 2", stationCity = "Coimbra" },
                    new CarStation { stationAdress = "Rua Belele 3", stationCity = "Coimbra" },
                    new CarStation { stationAdress = "Rua Belele 4", stationCity = "Coimbra" },
                    new CarStation { stationAdress = "Rua Belele 5", stationCity = "Coimbra" }
                    };
                    context.CarStations.AddRange(stations);
                    context.SaveChanges();
                }

                // Vehicles
                if (context.Vehicles.Count() == 0)
                {
                    var vehicles = new List<Vehicle>{
                        new Vehicle { vehicleOwner = 2, currentStation = 2, vehicleType = Vehicle.VehicleType.BIKE.ToString(), inUse = false, pricePerMinute = 20, isForTourism = false, isSmallSized = true, remainingBattery = 15 },
                        new Vehicle { vehicleOwner = 2, currentStation = 3, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 50, isForTourism = true, isSmallSized = false, remainingBattery = 100 },
                        new Vehicle { vehicleOwner = 4, currentStation = 4, vehicleType = Vehicle.VehicleType.MOTORBIKE.ToString(), inUse = false, pricePerMinute = 10, isForTourism = false, isSmallSized = true, remainingBattery = 10 },
                        new Vehicle { vehicleOwner = 3, currentStation = 5, vehicleType = Vehicle.VehicleType.SCOOTER.ToString(), inUse = true, pricePerMinute = 30, isForTourism = true, isSmallSized = true, remainingBattery = 70 },
                        new Vehicle { vehicleOwner = 5, currentStation = 6, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = false, pricePerMinute = 20, isForTourism = false, isSmallSized = false, remainingBattery = 100 },
                        new Vehicle { vehicleOwner = 1, currentStation = 2, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 10, isForTourism = true, isSmallSized = true, remainingBattery = 50 },
                        new Vehicle { vehicleOwner = 3, currentStation = 8, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 50, isForTourism = false, isSmallSized = true, remainingBattery = 100 },
                        new Vehicle { vehicleOwner = 1, currentStation = 7, vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = false, pricePerMinute = 70, isForTourism = true, isSmallSized = false, remainingBattery = 100 }
                    };
                    context.Vehicles.AddRange(vehicles);
                    context.SaveChanges();
                }

                // Reservations
                if (context.Reservations.Count() == 0)
                {
                    var reservations = new List<Reservation>{
                        new Reservation { UserNIBID = 1, VehicleID = 1, idStationIdstart = 1, idStationIdEnd = 2, predictedUseTime = 5, predictedCost = 5},
                        new Reservation { UserNIBID = 2, VehicleID = 2, idStationIdstart = 1, idStationIdEnd = 3, predictedUseTime = 20, predictedCost = 20},
                        new Reservation { UserNIBID = 3, VehicleID = 3, idStationIdstart = 2, idStationIdEnd = 3, predictedUseTime = 10, predictedCost = 10},
                        new Reservation { UserNIBID = 3, VehicleID = 4, idStationIdstart = 2, idStationIdEnd = 3, predictedUseTime = 20, predictedCost = 20},
                        new Reservation { UserNIBID = 2, VehicleID = 5, idStationIdstart = 2, idStationIdEnd = 4, predictedUseTime = 10, predictedCost = 500}
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
