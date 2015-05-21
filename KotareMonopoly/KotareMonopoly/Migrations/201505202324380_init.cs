namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        Board_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_Id)
                .Index(t => t.Board_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Money = c.Int(nullable: false),
                        CurrentLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.CurrentLocation_Id)
                .Index(t => t.CurrentLocation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "CurrentLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Board_Id", "dbo.Boards");
            DropIndex("dbo.Players", new[] { "CurrentLocation_Id" });
            DropIndex("dbo.Locations", new[] { "Board_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Locations");
            DropTable("dbo.Boards");
        }
    }
}
