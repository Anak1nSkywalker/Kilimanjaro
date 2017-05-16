namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloatToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicle", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "Width", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "Length", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "UsefulAreaHeight", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "UsefulAreaWidth", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "UsefulAreaLength", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "UsefulAreaLength", c => c.Double());
            AlterColumn("dbo.Vehicle", "UsefulAreaWidth", c => c.Double());
            AlterColumn("dbo.Vehicle", "UsefulAreaHeight", c => c.Double());
            AlterColumn("dbo.Vehicle", "Length", c => c.Double(nullable: false));
            AlterColumn("dbo.Vehicle", "Width", c => c.Double(nullable: false));
            AlterColumn("dbo.Vehicle", "Height", c => c.Double(nullable: false));
            AlterColumn("dbo.Vehicle", "Weight", c => c.Double(nullable: false));
        }
    }
}
