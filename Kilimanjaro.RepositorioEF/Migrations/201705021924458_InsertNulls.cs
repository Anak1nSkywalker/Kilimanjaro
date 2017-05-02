namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertNulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "SecundaryDdd", c => c.Int());
            AlterColumn("dbo.Patient", "SecundaryFone", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "SecundaryFone", c => c.Int(nullable: false));
            AlterColumn("dbo.Patient", "SecundaryDdd", c => c.Int(nullable: false));
        }
    }
}
