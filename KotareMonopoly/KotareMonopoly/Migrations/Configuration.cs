using KotareMonopoly.Models;

namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KotareMonopoly.Plumbing.KotareMonopolyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KotareMonopoly.Plumbing.KotareMonopolyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Players.AddOrUpdate(
              p => p.Hours,
              new Player { Hours = 0, CurrentPositionId = 0},
              new Player { Hours = 0, CurrentPositionId = 0}
              
            );
            
        }
    }
}
