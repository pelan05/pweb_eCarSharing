namespace pweb_eCarSharing.Migrations
{
    using pweb_eCarSharing.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<pweb_eCarSharing.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(pweb_eCarSharing.Models.ApplicationDbContext context)
        {
            // Add admin role
            if(!(context.Roles.Where(r => r.Name == "Admin").First().Name == "Admin"))
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

            /*
                        // Mock data
                        // Vehicles
                        var vehicles = new List<Vehicle> {
                                new Vehicle { vehicleType = Vehicle.VehicleType.BIKE.ToString(), inUse = false, pricePerMinute = 20 },
                                new Vehicle { vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = true, pricePerMinute = 50 },
                                new Vehicle { vehicleType = Vehicle.VehicleType.MOTORBIKE.ToString(), inUse = false, pricePerMinute = 10 },
                                new Vehicle { vehicleType = Vehicle.VehicleType.SCOOTER.ToString(), inUse = true, pricePerMinute = 30 },
                                new Vehicle { vehicleType = Vehicle.VehicleType.FOURWHEELED.ToString(), inUse = false, pricePerMinute = 20 }
                        };

                        context.Vehicles.AddRange(vehicles);
                        context.SaveChanges();
                    
                    */
        }
    }
}
