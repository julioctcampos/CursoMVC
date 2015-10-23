namespace GTAC.GTACAir.Persistence.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Component : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COMPONENTS",
                c => new
                    {
                        CMP_ID = c.Int(nullable: false, identity: true),
                        CMP_TITLE = c.String(nullable: false, maxLength: 50),
                        CMP_MANUFACTURER = c.String(nullable: false, maxLength: 50),
                        AIR_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CMP_ID)
                .ForeignKey("dbo.AIRCRAFT", t => t.AIR_ID, cascadeDelete: true)
                .Index(t => t.AIR_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.COMPONENTS", "AIR_ID", "dbo.AIRCRAFT");
            DropIndex("dbo.COMPONENTS", new[] { "AIR_ID" });
            DropTable("dbo.COMPONENTS");
        }
    }
}
