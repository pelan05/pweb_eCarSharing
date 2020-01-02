namespace pweb_eCarSharing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belele : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "address", c => c.String());
            DropColumn("dbo.Users", "adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "adress", c => c.String());
            DropColumn("dbo.Users", "address");
        }
    }
}
