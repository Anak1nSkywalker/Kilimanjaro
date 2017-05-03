namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "ConfirmationPassword", c => c.String(maxLength: 255));
            AddColumn("dbo.Customer", "ServiceProvider", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customer", "isServiceProvider");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "isServiceProvider", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customer", "ServiceProvider");
            DropColumn("dbo.Customer", "ConfirmationPassword");
        }
    }
}
