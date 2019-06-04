namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(maxLength: 200),
                        Word2 = c.String(maxLength: 200),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Text = c.String(storeType: "ntext"),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 50),
                        Message = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Ingredients = c.String(storeType: "ntext"),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuUpdates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Text = c.String(maxLength: 350),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(maxLength: 250),
                        DateTime = c.DateTime(nullable: false, storeType: "date"),
                        Title = c.String(maxLength: 250),
                        Text = c.String(storeType: "ntext"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Photo = c.String(maxLength: 250),
                        Text = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 50),
                        Time = c.DateTimeOffset(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Seats = c.Int(nullable: false),
                        SpecialRequests = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReserveTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seats = c.Int(nullable: false),
                        Name = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Time = c.Time(nullable: false, precision: 7),
                        SpecialRequests = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(maxLength: 250),
                        Title = c.String(maxLength: 250),
                        Text = c.String(storeType: "ntext"),
                        Icon = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 350),
                        Facebook = c.String(maxLength: 350),
                        Instagram = c.String(maxLength: 350),
                        Phone = c.String(maxLength: 50),
                        NavbarPhoto = c.String(maxLength: 350),
                        Adress = c.String(maxLength: 250),
                        Map = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Text = c.String(storeType: "ntext"),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Welcomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 150),
                        Text = c.String(maxLength: 350),
                        Phone = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "UserId", "dbo.Users");
            DropIndex("dbo.News", new[] { "UserId" });
            DropTable("dbo.Welcomes");
            DropTable("dbo.Teas");
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.ReserveTables");
            DropTable("dbo.Reservations");
            DropTable("dbo.Properties");
            DropTable("dbo.Users");
            DropTable("dbo.News");
            DropTable("dbo.MenuUpdates");
            DropTable("dbo.Menus");
            DropTable("dbo.ContactForms");
            DropTable("dbo.Contacts");
            DropTable("dbo.Abouts");
        }
    }
}
