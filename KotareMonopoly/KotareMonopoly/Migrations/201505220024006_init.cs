namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "centralhub.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "centralhub.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        NumberOfHouses = c.Int(nullable: false),
                        Owner_Id = c.Int(),
                        Board_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("centralhub.Players", t => t.Owner_Id)
                .ForeignKey("centralhub.Boards", t => t.Board_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Board_Id);
            
            CreateTable(
                "centralhub.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hours = c.Int(nullable: false),
                        CurrentPositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("centralhub.Locations", "Board_Id", "centralhub.Boards");
            DropForeignKey("centralhub.Locations", "Owner_Id", "centralhub.Players");
            DropIndex("centralhub.Locations", new[] { "Board_Id" });
            DropIndex("centralhub.Locations", new[] { "Owner_Id" });
            DropTable("centralhub.Players");
            DropTable("centralhub.Locations");
            DropTable("centralhub.Boards");
        }
    }
}
