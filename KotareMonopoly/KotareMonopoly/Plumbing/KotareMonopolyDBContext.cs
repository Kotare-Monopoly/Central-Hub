using KotareMonopoly.Models;

namespace KotareMonopoly.Plumbing
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KotareMonopolyDBContext : DbContext
    {
        // Your context has been configured to use a 'KotareMonopolyDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KotareMonopoly.Plumbing.KotareMonopolyDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KotareMonopolyDBContext' 
        // connection string in the application configuration file.
        public KotareMonopolyDBContext()
            : base("name=KotareMonopolyDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("centralhub");
            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}