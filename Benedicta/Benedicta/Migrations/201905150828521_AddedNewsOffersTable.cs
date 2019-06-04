namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewsOffersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(maxLength: 200),
                        Title = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsOffers");
        }
    }
}
