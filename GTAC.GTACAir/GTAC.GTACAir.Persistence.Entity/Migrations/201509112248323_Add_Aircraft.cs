namespace GTAC.GTACAir.Persistence.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Add_Aircraft : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AIRCRAFT",
                c => new
                {
                    AIC_ID = c.Int(nullable: false, identity: true),
                    AIC_MODEL = c.String(nullable: false, maxLength: 10),
                    AIC_PREFFIX = c.String(nullable: false, maxLength: 6),
                    AIC_SEAT_COUNT = c.Int(),
                    AIC_MANUFACTURER_SITE = c.String(maxLength: 10),
                })
                .PrimaryKey(t => t.AIC_ID);
        }

        public override void Down()
        {
            DropTable("dbo.AIRCRAFT");
        }
    }
}