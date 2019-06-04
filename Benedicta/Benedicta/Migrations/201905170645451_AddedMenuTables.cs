namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMenuTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuT1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Text = c.String(storeType: "ntext"),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuT2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Text = c.String(storeType: "ntext"),
                        Photo = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuT2");
            DropTable("dbo.MenuT1");
        }
    }
}
