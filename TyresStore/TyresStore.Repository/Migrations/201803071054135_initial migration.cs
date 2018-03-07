namespace TyresStore.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Basket", "Season", c => c.String());
            AddColumn("dbo.Basket", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Basket", "ArticleCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Basket", "ArticleCode");
            DropColumn("dbo.Basket", "Price");
            DropColumn("dbo.Basket", "Season");
        }
    }
}
