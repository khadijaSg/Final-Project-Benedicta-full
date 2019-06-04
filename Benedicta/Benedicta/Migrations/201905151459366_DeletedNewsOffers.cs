namespace Benedicta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedNewsOffers : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NewsOffers");
        }
        
        public override void Down()
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
    }
}
