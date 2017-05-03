namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "ConfirmationPassword", c => c.String(maxLength: 255));
            AddColumn("dbo.Customer", "isServiceProvider", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false, maxLength: 120, unicode: false));
            DropColumn("dbo.Customer", "isServiceProvider");
            DropColumn("dbo.Customer", "ConfirmationPassword");
        }
    }
}
