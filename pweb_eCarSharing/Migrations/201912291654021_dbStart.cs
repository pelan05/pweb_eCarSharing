namespace pweb_eCarSharing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                        adress = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        email = c.String(nullable: false),
                        NIB = c.String(nullable: false, maxLength: 21),
                    })
                .PrimaryKey(t => t.userID);
            
            CreateTable(
                "dbo.CarStations",
                c => new
                    {
                        stationId = c.Int(nullable: false, identity: true),
                        stationCity = c.String(nullable: false, maxLength: 15),
                        stationAdress = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.stationId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        idStationIdstart = c.Int(nullable: false),
                        idStationIdEnd = c.Int(nullable: false),
                        predictedUseTime = c.Int(nullable: false),
                        predictedCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.CarStations", t => t.idStationIdEnd, cascadeDelete: false)
                .ForeignKey("dbo.CarStations", t => t.idStationIdstart, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.VehicleID)
                .Index(t => t.idStationIdstart)
                .Index(t => t.idStationIdEnd);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        vehicleOwner = c.Int(nullable: false),
                        currentStation = c.Int(nullable: false),
                        vehicleType = c.String(nullable: false),
                        isSmallSized = c.Boolean(nullable: false),
                        isForTourism = c.Boolean(nullable: false),
                        inUse = c.Boolean(nullable: false),
                        pricePerMinute = c.Single(nullable: false),
                        remainingBattery = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.CarStations", t => t.currentStation, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.vehicleOwner, cascadeDelete: true)
                .Index(t => t.vehicleOwner)
                .Index(t => t.currentStation);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reservations", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "vehicleOwner", "dbo.Users");
            DropForeignKey("dbo.Vehicles", "currentStation", "dbo.CarStations");
            DropForeignKey("dbo.Reservations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reservations", "idStationIdstart", "dbo.CarStations");
            DropForeignKey("dbo.Reservations", "idStationIdEnd", "dbo.CarStations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Vehicles", new[] { "currentStation" });
            DropIndex("dbo.Vehicles", new[] { "vehicleOwner" });
            DropIndex("dbo.Reservations", new[] { "idStationIdEnd" });
            DropIndex("dbo.Reservations", new[] { "idStationIdstart" });
            DropIndex("dbo.Reservations", new[] { "VehicleID" });
            DropIndex("dbo.Reservations", new[] { "UserID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Reservations");
            DropTable("dbo.CarStations");
            DropTable("dbo.Users");
        }
    }
}
