namespace TyresStore.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Basket",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Season = c.String(),
                        Price = c.Double(nullable: false),
                        ArticleCode = c.String(),
                        TyreId = c.Int(nullable: false),
                        AddedDate = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tyre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        Brand = c.String(),
                        Season = c.String(),
                        ArticleCode = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tyre", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.Tyre", new[] { "VehicleId" });
            DropTable("dbo.Vehicle");
            DropTable("dbo.Tyre");
            DropTable("dbo.Basket");
        }
    }
}
