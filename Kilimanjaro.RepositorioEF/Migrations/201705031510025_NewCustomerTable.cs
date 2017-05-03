namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75, unicode: false),
                        Birthdate = c.DateTime(nullable: false, storeType: "date"),
                        Cpf = c.Int(nullable: false),
                        Ddd = c.Int(nullable: false),
                        Fone = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 40, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastChangeDate = c.DateTime(),
                        Password = c.String(nullable: false, maxLength: 120, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
