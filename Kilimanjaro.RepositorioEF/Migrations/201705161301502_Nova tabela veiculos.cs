namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novatabelaveiculos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identification = c.String(nullable: false, maxLength: 7, unicode: false),
                        Chassis = c.String(nullable: false, maxLength: 17, unicode: false),
                        Year = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        UsefulAreaHeight = c.Double(),
                        UsefulAreaWidth = c.Double(),
                        UsefulAreaLength = c.Double(),
                        CreationDate = c.DateTime(nullable: false),
                        LastChangeDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicle");
        }
    }
}
