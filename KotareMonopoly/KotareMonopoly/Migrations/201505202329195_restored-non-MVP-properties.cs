namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restorednonMVPproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "NumberOfHouses", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "Player_Id", c => c.Int());
            AddColumn("dbo.Locations", "PlayerId_Id", c => c.Int());
            CreateIndex("dbo.Locations", "Player_Id");
            CreateIndex("dbo.Locations", "PlayerId_Id");
            AddForeignKey("dbo.Locations", "Player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Locations", "PlayerId_Id", "dbo.Players", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "PlayerId_Id", "dbo.Players");
            DropForeignKey("dbo.Locations", "Player_Id", "dbo.Players");
            DropIndex("dbo.Locations", new[] { "PlayerId_Id" });
            DropIndex("dbo.Locations", new[] { "Player_Id" });
            DropColumn("dbo.Locations", "PlayerId_Id");
            DropColumn("dbo.Locations", "Player_Id");
            DropColumn("dbo.Locations", "NumberOfHouses");
        }
    }
}
