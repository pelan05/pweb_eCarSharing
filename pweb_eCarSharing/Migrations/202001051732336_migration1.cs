namespace pweb_eCarSharing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarStations",
                c => new
                    {
                        stationId = c.Int(nullable: false, identity: true),
                        stationCity = c.String(nullable: false, maxLength: 15),
                        stationAdress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.stationId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        UserNIBID = c.Int(),
                        VehicleID = c.Int(nullable: false),
                        idStationIdstart = c.Int(),
                        idStationIdEnd = c.Int(),
                        predictedUseTime = c.Int(nullable: false),
                        predictedCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.CarStations", t => t.idStationIdEnd)
                .ForeignKey("dbo.CarStations", t => t.idStationIdstart)
                .ForeignKey("dbo.UserNIBs", t => t.UserNIBID)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.UserNIBID)
                .Index(t => t.VehicleID)
                .Index(t => t.idStationIdstart)
                .Index(t => t.idStationIdEnd);
            
            CreateTable(
                "dbo.UserNIBs",
                c => new
                    {
                        userNIBID = c.Int(nullable: false, identity: true),
                        userIDstring = c.String(),
                        NIB = c.String(nullable: false, maxLength: 21),
                        Role = c.String(nullable: false, maxLength: 7),
                    })
                .PrimaryKey(t => t.userNIBID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        vehicleOwner = c.Int(),
                        currentStation = c.Int(),
                        vehicleType = c.String(nullable: false),
                        isSmallSized = c.Boolean(nullable: false),
                        isForTourism = c.Boolean(nullable: false),
                        inUse = c.Boolean(nullable: false),
                        pricePerMinute = c.Int(nullable: false),
                        remainingBattery = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.CarStations", t => t.currentStation)
                .ForeignKey("dbo.UserNIBs", t => t.vehicleOwner)
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
            DropForeignKey("dbo.Vehicles", "vehicleOwner", "dbo.UserNIBs");
            DropForeignKey("dbo.Vehicles", "currentStation", "dbo.CarStations");
            DropForeignKey("dbo.Reservations", "UserNIBID", "dbo.UserNIBs");
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
            DropIndex("dbo.Reservations", new[] { "UserNIBID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Vehicles");
            DropTable("dbo.UserNIBs");
            DropTable("dbo.Reservations");
            DropTable("dbo.CarStations");
        }
    }
}
