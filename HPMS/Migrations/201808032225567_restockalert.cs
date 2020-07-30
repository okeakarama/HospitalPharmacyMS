namespace HPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restockalert : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drugs", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drugs", "Quantity", c => c.String(nullable: false));
        }
    }
}
