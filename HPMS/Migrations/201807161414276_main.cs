namespace HPMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class main : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Firstname = c.String(nullable: false),
                        Othername = c.String(),
                        Gender = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Occupation = c.String(),
                        Telephone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        DrugID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Quantity = c.String(nullable: false),
                        Rack = c.String(),
                    })
                .PrimaryKey(t => t.DrugID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drugs");
            DropTable("dbo.Patients");
            DropTable("dbo.UserProfile");
        }
    }
}
