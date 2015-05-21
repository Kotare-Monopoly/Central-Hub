namespace KotareMonopoly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schemaname : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Boards", newSchema: "centralhub");
            MoveTable(name: "dbo.Locations", newSchema: "centralhub");
            MoveTable(name: "dbo.Players", newSchema: "centralhub");
        }
        
        public override void Down()
        {
            MoveTable(name: "centralhub.Players", newSchema: "dbo");
            MoveTable(name: "centralhub.Locations", newSchema: "dbo");
            MoveTable(name: "centralhub.Boards", newSchema: "dbo");
        }
    }
}
