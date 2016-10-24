namespace JqueryWebApiITCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeOnMarketCap : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "MarketCap", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "MarketCap", c => c.Single(nullable: false));
        }
    }
}
