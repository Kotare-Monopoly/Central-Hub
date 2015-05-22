namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_hours : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("centralhub.Players", "CurrentLocation_Id", "centralhub.Locations");
            DropIndex("centralhub.Players", new[] { "CurrentLocation_Id" });
            RenameColumn(table: "centralhub.Locations", name: "Player_Id", newName: "Owner_Id");
            RenameIndex(table: "centralhub.Locations", name: "IX_Player_Id", newName: "IX_Owner_Id");
            AddColumn("centralhub.Players", "Hours", c => c.Int(nullable: false));
            AddColumn("centralhub.Players", "CurrentPositionId", c => c.Int(nullable: false));
            DropColumn("centralhub.Players", "Money");
            DropColumn("centralhub.Players", "CurrentLocation_Id");
        }
        
        public override void Down()
        {
            AddColumn("centralhub.Players", "CurrentLocation_Id", c => c.Int());
            AddColumn("centralhub.Players", "Money", c => c.Int(nullable: false));
            DropColumn("centralhub.Players", "CurrentPositionId");
            DropColumn("centralhub.Players", "Hours");
            RenameIndex(table: "centralhub.Locations", name: "IX_Owner_Id", newName: "IX_Player_Id");
            RenameColumn(table: "centralhub.Locations", name: "Owner_Id", newName: "Player_Id");
            CreateIndex("centralhub.Players", "CurrentLocation_Id");
            AddForeignKey("centralhub.Players", "CurrentLocation_Id", "centralhub.Locations", "Id");
        }
    }
}
