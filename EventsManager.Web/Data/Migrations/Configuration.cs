using EventsManager.Web.Domain.Entities;

namespace EventsManager.Web.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventsManager.Web.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(EventsManager.Web.Data.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name, 
                new ApplicationRole("Administrator"),
                new ApplicationRole("User")
            );
        }
    }
}
