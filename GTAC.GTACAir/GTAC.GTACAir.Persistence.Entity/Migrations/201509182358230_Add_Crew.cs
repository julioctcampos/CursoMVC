namespace GTAC.GTACAir.Persistence.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Crew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CREW",
                c => new
                    {
                        CRW_ID = c.Int(nullable: false, identity: true),
                        CRW_NAME = c.String(nullable: false, maxLength: 30),
                        CRW_ANAC_CODE = c.String(nullable: false, maxLength: 6),
                        CRW_COMPANY_NUMBER = c.String(nullable: false, maxLength: 8),
                        CRW_ACTIVE = c.Boolean(nullable: false),
                        CRW_NICKNAME = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CRW_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CREW");
        }
    }
}
