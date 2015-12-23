namespace Kilimanjaro.RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Backyard = c.String(nullable: false, maxLength: 30, unicode: false),
                        Number = c.String(nullable: false, maxLength: 5, unicode: false),
                        Complement = c.String(nullable: false, maxLength: 8, unicode: false),
                        Neighborhood = c.String(nullable: false, maxLength: 30, unicode: false),
                        City = c.String(nullable: false, maxLength: 30, unicode: false),
                        ZipCode = c.Int(nullable: false),
                        BackyardType_Id = c.Int(),
                        FederativeUnit_Id = c.Int(),
                        Patient_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BackyardType", t => t.BackyardType_Id)
                .ForeignKey("dbo.FederativeUnit", t => t.FederativeUnit_Id)
                .ForeignKey("dbo.Patient", t => t.Patient_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.BackyardType_Id)
                .Index(t => t.FederativeUnit_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.BackyardType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FederativeUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Acronym = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        Birthdate = c.DateTime(nullable: false, storeType: "date"),
                        Rg = c.String(nullable: false, maxLength: 20, unicode: false),
                        Cpf = c.Int(nullable: false),
                        MotherName = c.String(nullable: false, maxLength: 75, unicode: false),
                        PrimaryDdd = c.Int(nullable: false),
                        PrimaryFone = c.Int(nullable: false),
                        SecundaryDdd = c.Int(nullable: false),
                        SecundaryFone = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 40, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastChangeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 75, unicode: false),
                        Name = c.String(nullable: false, maxLength: 75, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        Birthdate = c.DateTime(nullable: false),
                        Rg = c.String(nullable: false, maxLength: 20, unicode: false),
                        Cpf = c.Int(nullable: false),
                        PrimaryDdd = c.Int(nullable: false),
                        PrimaryFone = c.Int(nullable: false),
                        SecondaryDdd = c.Int(),
                        SecondaryFone = c.Int(),
                        Email = c.String(maxLength: 40, unicode: false),
                        CreationDate = c.DateTime(),
                        LastChangeDate = c.DateTime(),
                        Password = c.String(nullable: false, maxLength: 15, unicode: false),
                        UserType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserType", t => t.UserType_Id)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Odontologist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OdontologistType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Record",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CriationDate = c.DateTime(nullable: false),
                        LastChangeDate = c.DateTime(nullable: false),
                        TreatmentDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                        Observation = c.String(nullable: false, maxLength: 255, unicode: false),
                        AttendantUser_Id = c.Int(),
                        OdontologistUser_Id = c.Int(),
                        Patient_Id = c.Int(),
                        RecordStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.AttendantUser_Id)
                .ForeignKey("dbo.User", t => t.OdontologistUser_Id)
                .ForeignKey("dbo.Patient", t => t.Patient_Id)
                .ForeignKey("dbo.RecordStatus", t => t.RecordStatus_Id)
                .Index(t => t.AttendantUser_Id)
                .Index(t => t.OdontologistUser_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.RecordStatus_Id);
            
            CreateTable(
                "dbo.RecordStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Record", "RecordStatus_Id", "dbo.RecordStatus");
            DropForeignKey("dbo.Record", "Patient_Id", "dbo.Patient");
            DropForeignKey("dbo.Record", "OdontologistUser_Id", "dbo.User");
            DropForeignKey("dbo.Record", "AttendantUser_Id", "dbo.User");
            DropForeignKey("dbo.Address", "User_Id", "dbo.User");
            DropForeignKey("dbo.User", "UserType_Id", "dbo.UserType");
            DropForeignKey("dbo.Address", "Patient_Id", "dbo.Patient");
            DropForeignKey("dbo.Address", "FederativeUnit_Id", "dbo.FederativeUnit");
            DropForeignKey("dbo.Address", "BackyardType_Id", "dbo.BackyardType");
            DropIndex("dbo.Record", new[] { "RecordStatus_Id" });
            DropIndex("dbo.Record", new[] { "Patient_Id" });
            DropIndex("dbo.Record", new[] { "OdontologistUser_Id" });
            DropIndex("dbo.Record", new[] { "AttendantUser_Id" });
            DropIndex("dbo.User", new[] { "UserType_Id" });
            DropIndex("dbo.Address", new[] { "User_Id" });
            DropIndex("dbo.Address", new[] { "Patient_Id" });
            DropIndex("dbo.Address", new[] { "FederativeUnit_Id" });
            DropIndex("dbo.Address", new[] { "BackyardType_Id" });
            DropTable("dbo.RecordStatus");
            DropTable("dbo.Record");
            DropTable("dbo.OdontologistType");
            DropTable("dbo.Odontologist");
            DropTable("dbo.UserType");
            DropTable("dbo.User");
            DropTable("dbo.Patient");
            DropTable("dbo.FederativeUnit");
            DropTable("dbo.BackyardType");
            DropTable("dbo.Address");
        }
    }
}
