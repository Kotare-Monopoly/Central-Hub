namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeplayerid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "PlayerId_Id", "dbo.Players");
            DropIndex("dbo.Locations", new[] { "PlayerId_Id" });
            DropColumn("dbo.Locations", "PlayerId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "PlayerId_Id", c => c.Int());
            CreateIndex("dbo.Locations", "PlayerId_Id");
            AddForeignKey("dbo.Locations", "PlayerId_Id", "dbo.Players", "Id");
        }
    }
}
