namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBirthdateDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "Birthdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
