namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigracion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "ConfirmationPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "ConfirmationPassword", c => c.String(maxLength: 255));
        }
    }
}
