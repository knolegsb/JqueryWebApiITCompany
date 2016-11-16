namespace JqueryWebApiITCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFiscalYearColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "FiscalYear", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "FiscalYear", c => c.DateTime(nullable: false));
        }
    }
}
