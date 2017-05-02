namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Patient", "LastChangeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "LastChangeDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patient", "Birthdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
