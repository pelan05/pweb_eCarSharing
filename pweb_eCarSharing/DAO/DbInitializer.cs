using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pweb_eCarSharing.Models;

namespace e_CarSharing.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            var vehicles = new List<Vehicle> {
                    new Vehicle { vehicleType = Vehicle.VehicleType.BIKE.ToString(), inUse = false, pricePerMinute = 20 },
                    new Vehicle { vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 50 },
                    new Vehicle { vehicleType = Vehicle.VehicleType.MOTORBIKE.ToString(), inUse = false, pricePerMinute = 10 },
                    new Vehicle { vehicleType = Vehicle.VehicleType.SCOOTER.ToString(), inUse = true, pricePerMinute = 30 },
                    new Vehicle { vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = false, pricePerMinute = 20 }
            };

            vehicles.ForEach(s => context.Vehicles.Add(s));
            context.SaveChanges();

            var users = new List<User> {
                    new User {name = "pedro", username = "pelan", password = "123", isAdmin = false, email = "pelan@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime()  },
                    new User {name = "guilherme", username = "gigi", password = "123", isAdmin = false, email = "gigi@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime()  },
                    new User {name = "paulo", username = "paul5", password = "123", isAdmin = false, email = "paul5@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime() },
                    new User {name = "tania", username = "tanita", password = "123", isAdmin = false, email = "tanita@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime()  },
                    new User {name = "diana", username = "didi09", password = "123", isAdmin = false, email = "didi09@gmail.com", NIB = "123456789012345678901", birthDate = new DateTime() }
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var carStations = new List<CarStation> {
                    new CarStation { stationCity = "Porto", stationAdress = "Rua das Baterias, 158" },
                    new CarStation { stationCity = "Lisboa", stationAdress = "Rua das Tomadas, 123" },
                    new CarStation { stationCity = "Algarve", stationAdress = "Rua das Portas, 999" },
                    new CarStation { stationCity = "Porto", stationAdress = "Rua das Casas, 666" },
                    new CarStation { stationCity = "Coimbra", stationAdress = "Rua do Brasil, 133" }
            };

            carStations.ForEach(s => context.CarStations.Add(s));
            context.SaveChanges();

            var reservations = new List<Reservation> {
                    new Reservation { predictedUseTime = 5, predictedCost = 5 },
                    new Reservation { predictedUseTime = 4, predictedCost = 4 },
                    new Reservation { predictedUseTime = 3, predictedCost = 3 },
                    new Reservation { predictedUseTime = 2, predictedCost = 2 },
                    new Reservation { predictedUseTime = 1, predictedCost = 1 }
            };

            reservations.ForEach(s => context.Reservations.Add(s));
            context.SaveChanges();




        }
    }
}