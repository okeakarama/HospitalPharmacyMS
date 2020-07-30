namespace HPMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<HPMS.Models.MainDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HPMS.Models.MainDBContext context)
        {

            WebSecurity.InitializeDatabaseConnection(
              "MainDBContext",
              "UserProfile",
              "UserId",
              "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");

            if (!WebSecurity.UserExists("admin"))
                WebSecurity.CreateUserAndAccount(
                    "admin",
                    "admin");
            if (!Roles.GetRolesForUser("admin").Contains("Admin"))
                Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
            
            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
