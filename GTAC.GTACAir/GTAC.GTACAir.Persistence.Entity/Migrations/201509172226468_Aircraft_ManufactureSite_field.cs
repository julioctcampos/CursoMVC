namespace GTAC.GTACAir.Persistence.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aircraft_ManufactureSite_field : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AIRCRAFT", "AIC_MANUFACTURER_SITE", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AIRCRAFT", "AIC_MANUFACTURER_SITE", c => c.String(maxLength: 10));
        }
    }
}
