namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBirthDatePatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
