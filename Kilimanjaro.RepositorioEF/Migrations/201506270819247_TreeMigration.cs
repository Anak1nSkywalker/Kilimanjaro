namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "UserType_Id", "dbo.UserType");
            DropIndex("dbo.User", new[] { "UserType_Id" });
            AlterColumn("dbo.User", "UserType_Id", c => c.Int());
            CreateIndex("dbo.User", "UserType_Id");
            AddForeignKey("dbo.User", "UserType_Id", "dbo.UserType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserType_Id", "dbo.UserType");
            DropIndex("dbo.User", new[] { "UserType_Id" });
            AlterColumn("dbo.User", "UserType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "UserType_Id");
            AddForeignKey("dbo.User", "UserType_Id", "dbo.UserType", "Id", cascadeDelete: true);
        }
    }
}
